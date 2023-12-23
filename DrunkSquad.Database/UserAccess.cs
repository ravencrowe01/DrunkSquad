using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database {
    public class UserAccess : EntityAccess<DSUser>, IUserAccess {
        public UserAccess (DbSet<DSUser> set) : base (set) { }

        public DSUser FindByApiKey (string key) => _set.FirstOrDefault (u => u.LoginDetails.ApiKey == key);
    }
}
