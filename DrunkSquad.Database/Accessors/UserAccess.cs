using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class UserAccess (DbSet<User> set, DbContext context) : EntityAccess<User> (set, context), IUserAccess {
        public User FindByApiKey (string key) => _set.Include (user => user.LoginDetails).Include (user => user.Profile).FirstOrDefault (user => user.LoginDetails.ApiKey == key);

        public User FindByProfileID (int id) {
            var found = _set.Include (user => user.LoginDetails).Include(user => user.Profile).FirstOrDefault (user => user.Profile.ProfileID == id);

            return found;
        }
    }
}
