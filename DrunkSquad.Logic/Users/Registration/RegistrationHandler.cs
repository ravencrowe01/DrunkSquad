using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users.Registration {
    public class RegistrationHandler (IPasswordHasher<LoginDetails> hasher, IApiRequestClient apiClient, IWebsiteConfig config, IUserAccess userAccess) : IRegistrationHandler {
        private IPasswordHasher<LoginDetails> _hasher = hasher;
        private static readonly string [] selections = ["profile"];

        public async Task<RegistrationStatus> RegisterAsync (LoginDetails details) {
            var found = userAccess.FindByApiKey (details.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            var requiredLevel = config.Api.RequiredAccessLevel;

            var result = await apiClient.GetAsync<Profile> (new RequestConfiguration {
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

            found = userAccess.FindByProfileID (result.Content.ProfileID);

            if (found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            found = new User ();

            var profile = result.Content;

            found.Profile = profile;
            found.LoginDetails = details;
            found.LoginDetails.Password = _hasher.HashPassword (details, details.Password);

            userAccess.Add (found);

            return RegistrationStatus.Registered;
        }
    }
}
