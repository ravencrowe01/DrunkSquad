using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DrunkSquad.Database.Accessors {
    public class UserAccess (DbSet<User> set, DbContext context) : EntityAccess<User> (set, context), IUserAccess {
        public User FindByApiKey (string key) => WithLoginDetails ().FirstOrDefault (user => user.LoginDetails.ApiKey == key);

        public User FindByProfileID (int id) {
            var found = WithLoginDetails ().FirstOrDefault (user => user.Profile.ProfileID == id);

            return found;
        }

        private IIncludableQueryable<User, LoginDetails> WithLoginDetails () {
            return _set.Include (user => user.LoginDetails);
        }
    }
}
