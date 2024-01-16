using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public class ProfileHandler (IApiRequestClient client, IWebsiteConfig config, IProfileAccess profileAccess) : IProfileHandler {
        public async Task<IApiResponse<Profile>> FetchProfileAsync (int id) {
            RequestConfiguration requestConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                ID = id,
                Section = "user",
                Selections = ["profile"],
                Comment = "Drunk Squad Profile Fetch"
            };
            var response = await client.GetAsync<Profile> (requestConfig, config.Api.RequiredAccessLevel);

            return response;
        }

        public void AddProfile (Profile profile) => profileAccess.Add (profile);

        public void AddProfiles (IEnumerable<Profile> profiles) => profileAccess.AddRange (profiles);
    }
}
