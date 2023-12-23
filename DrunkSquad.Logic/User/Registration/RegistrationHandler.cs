using DrunkSquad.Database;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TornApi.Net.Models.Key;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.User.Registration {
    public class RegistrationHandler (IPasswordHasher<DSUser> hasher, IHttpClientFactory clientFactory, IConfigurationManager config, IUserAccess users) : IRegistrationHandler {
        private readonly ApiRequestClient _client = new ApiRequestClient (clientFactory, config.GetSection ("Api") ["BaseApiUrl"]);
        private static readonly string [] selections = new string [] { "profile" };

        public async Task<RegistrationStatus> RegisterAsync (DSUser user) {
            var found = users.FindByApiKey (user.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            ApiResponse<DSUser> result = await _client.GetSingleObjectAsync<DSUser> (new RequestConfiguration {
                Key = user.ApiKey,
                Section = "user",
                Selections = selections
            },
            (AccessLevel) int.Parse (config.GetSection ("api") ["RequiredApiLeve"]));

            if (!result.KeyStatus.IsKeyUsable) {
                return RegistrationStatus.InvalidKey;
            }

            if (result.HttpResponseMessage is null || result.HttpResponseMessage.IsSuccessStatusCode) {
                return RegistrationStatus.InvalidApiResponse;
            }

            if (result.Content is null) {
                return RegistrationStatus.NoResponse;
            }

            found = users.FindByID (result.Content.ID);

            if (found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            var profile = result.Content;

            profile.Password = hasher.HashPassword (profile, user.Password);
            profile.ApiKey = user.ApiKey;

            users.Add (profile);

            return RegistrationStatus.Registered;
        }
    }
}
