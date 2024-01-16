using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class ProfileAccess (DbSet<Profile> set, DbContext context) : EntityAccess<Profile> (set, context), IProfileAccess {
        public Profile FindByProfileID (int id) {
            throw new NotImplementedException ();
        }
    }
}
