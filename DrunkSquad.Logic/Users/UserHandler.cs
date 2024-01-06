using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Users;
using TornApi.Net.Models.Key;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public class UserHandler (IApiRequestClient client, IUserAccess userAccess) : IUserHandler {
        public async Task<IApiResponse<User>> FetchUserAsync (string key, int id) {
            var response = await client.GetAsync<User> (new RequestConfiguration {
                Key = key,
                ID = id,
                Section = "user",
                Selections = ["profile"],
                Comment = "Drunk Squad Profile Fetch"
            }, AccessLevel.PublicOnly);

            if (response.IsValid ()) {
                return response;
            }

            return null;
        }

        public void AddUser (User user) => userAccess.Add (user);

        public void AddUsers (IEnumerable<User> users) => userAccess.AddRange (users);
    }
}
