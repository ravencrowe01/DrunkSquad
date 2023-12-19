using DrunkSquad.Database;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.User {
    public class RegistrationHandler (IPasswordHasher<UserProfile> hasher, IUserDBAccess users, IHttpClientFactory clientFactory) : IRegistrationHandler {
        private ApiRequestClient _client = new ApiRequestClient (clientFactory, @"https://api.torn.com/");

        public async Task<RegistrationStatus> RegisterAsync (UserProfile user) {
            var found = users.FindByApiKey (user.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            ApiResponse<UserProfile> result = await _client.GetSingleObjectAsync<UserProfile> (new RequestConfiguration {
                Key = user.ApiKey,
                Section = "user",
                Selections = new string [] { "profile" }
            });

            if(!result.KeyStatus.IsKeyUsable) {
                return RegistrationStatus.InvalidKey;
            }

            if(result.HttpResponseMessage is null || result.HttpResponseMessage.IsSuccessStatusCode) {
                return RegistrationStatus.InvalidApiResponse;
            }

            if(result.Content is null) {
                return RegistrationStatus.NoResponse;
            }

            found = users.FindByID (result.Content.ID);

            if(found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            var profile = result.Content;

            profile.Password = hasher.HashPassword (profile, user.Password);
            profile.ApiKey = user.ApiKey;

            await users.AddAsync (profile);

            return RegistrationStatus.Registered;
        }
    }
}
