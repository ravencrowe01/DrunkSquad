using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database {
    public class UserAccess : EntityAccess<DSUser>, IUserAccess {
        public UserAccess (DbSet<DSUser> set, DbContext context) : base (set,  context) { }

        public DSUser FindByApiKey (string key) => _set.Include (u => u.LoginDetails).FirstOrDefault (u => u.LoginDetails.ApiKey == key);
    }
}
