using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
#pragma warning disable CS9113 // Parameter is unread.
    public class UserHandler (IApiRequestClient client, IWebsiteConfig config, IUserAccess userAccess) : IUserHandler {
#pragma warning restore CS9113 // Parameter is unread.
        public void AddUser (User user) => userAccess.Add (user);

        public void AddUsers (IEnumerable<User> users) => userAccess.AddRange (users);

        public IEnumerable<User> GetAllUsers () => userAccess.Set.Include (user => user.Profile);
    }
}
