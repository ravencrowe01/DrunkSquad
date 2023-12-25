using DrunkSquad.Database;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.User.Registration {
    public class RegistrationHandler (IPasswordHasher<LoginDetails> hasher, IHttpClientFactory clientFactory, IWebsiteConfig config, DrunkSquadDBContext db) : IRegistrationHandler {
        private IPasswordHasher<LoginDetails> _hasher = hasher;
        private readonly ApiRequestClient _client = new(clientFactory, config.GetBaseURL ());
        private static readonly string [] selections = ["profile"];

        public async Task<RegistrationStatus> RegisterAsync (LoginDetails details) {
            var found = db.UserAccess.FindByApiKey (details.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            var requiredLevel = config.GetRequiredAccessLevel ();

            ApiResponse<User> result = await _client.GetSingleObjectAsync<User> (new RequestConfiguration {
                Key = details.ApiKey,
                Section = "user",
                Selections = selections
            },
            requiredLevel);

            if (!result.KeyStatus.IsKeyUsable) {
                return RegistrationStatus.InvalidKey;
            }

            if (result.HttpResponseMessage is null || !result.HttpResponseMessage.IsSuccessStatusCode) {
                return RegistrationStatus.InvalidApiResponse;
            }

            if (result.Content is null) {
                return RegistrationStatus.NoResponse;
            }

            found = db.UserAccess.FindByID (result.Content.ID);

            if (found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            var profile = result.Content;

            profile.LoginDetails.Password = _hasher.HashPassword (details, details.Password);
            profile.LoginDetails.ApiKey = details.ApiKey;

            db.UserAccess.Add (profile);

            return RegistrationStatus.Registered;
        }
    }
}
