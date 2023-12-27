using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users.Registration {
    public class RegistrationHandler (IPasswordHasher<LoginDetails> hasher, IHttpClientFactory clientFactory, IWebsiteConfig config, IUserAccess userAccess) : IRegistrationHandler {
        private IPasswordHasher<LoginDetails> _hasher = hasher;
        private readonly ApiRequestClient _client = new (clientFactory, config.BaseURL);
        private static readonly string [] selections = ["profile"];

        public async Task<RegistrationStatus> RegisterAsync (LoginDetails details) {
            var found = userAccess.FindByApiKey (details.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            var requiredLevel = config.RequiredAccessLevel;

            ApiResponse<User> result = await _client.GetAsync<User> (new RequestConfiguration {
                Key = details.ApiKey,
                Section = "user",
                Selections = selections,
                Comment = "Drunk Squad User Registration"
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

            found = userAccess.FindByID (result.Content.ID);

            if (found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            var profile = result.Content;

            profile.LoginDetails.Password = _hasher.HashPassword (details, details.Password);
            profile.LoginDetails.ApiKey = details.ApiKey;

            userAccess.Add (profile);

            return RegistrationStatus.Registered;
        }
    }
}
