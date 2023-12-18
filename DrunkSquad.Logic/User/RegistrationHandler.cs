using DrunkSquad.Database;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.User {
    public class RegistrationHandler (IPasswordHasher<UserProfile> hasher, IUserDBAccess users, IHttpClientFactory clientFactory, IConfiguration config) : IRegistrationHandler {
        public async Task<RegistrationStatus> RegisterAsync (UserProfile user) {
            var found = users.FindByApiKey (user.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            user.Password = hasher.HashPassword (user, user.Password);

            var requestClient = new ApiRequestClient (clientFactory);

            var result = await requestClient.GetAsync (new RequestConfiguration {
                ApiUrl = config.GetValue<string> ("ApiConfig:BaseApiUrl") ?? @"https://api.torn.com/",
                Key = user.ApiKey,
                Section = "user",
                Selections = new string [] { "profile" }
            });

            if (result is null || !result.IsSuccessStatusCode) {
                return RegistrationStatus.NoResponse;
            }

            var json = await result.Content.ReadAsStringAsync ();

            if (json is null || json.Length <= 0) {
                return RegistrationStatus.InvalidKey;
            }

            var profile = JsonConvert.DeserializeObject<UserProfile> (json);

            if (profile is null) {
                return RegistrationStatus.InvalidKey;
            }

            profile.ApiKey = user.ApiKey;
            profile.Password = user.Password;

            await users.AddAsync (profile);

            return RegistrationStatus.Registered;
        }
    }
}
