using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class UserAccess (DbSet<User> set, DbContext context) : EntityAccess<User> (set, context), IUserAccess {
        public User FindByApiKey (string key) => _set.FirstOrDefault (user => user.LoginDetails.ApiKey == key);
    }
}
