using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database {
    public class UserAccess : EntityAccess<User>, IUserAccess {
        public UserAccess (DbSet<User> set, DbContext context) : base (set,  context) { }

        public User FindByApiKey (string key) => _set.Include (u => u.LoginDetails).FirstOrDefault (u => u.LoginDetails.ApiKey == key);
    }
}
