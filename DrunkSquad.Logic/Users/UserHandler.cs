using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using TornApi.Net.Models.Key;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public class UserHandler (IApiRequestClient client, IWebsiteConfig config, IUserAccess userAccess) : IUserHandler {
        public async Task<IApiResponse<User>> FetchUserAsync (int id) {
            var response = await client.GetAsync<User> (new RequestConfiguration {
                Key = config.Api.DefaultKey,
                ID = id,
                Section = "user",
                Selections = ["profile"],
                Comment = "Drunk Squad Profile Fetch"
            }, AccessLevel.PublicOnly);

            return response;
        }

        public void AddUser (User user) => userAccess.Add (user);

        public void AddUsers (IEnumerable<User> users) => userAccess.AddRange (users);

        public IEnumerable<User> GetAllUsers () => userAccess.Set.ToList ();
    }
}
