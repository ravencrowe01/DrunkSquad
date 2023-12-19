using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database {
    public class DrunkSquadDB : DbContext, IDrunkSquadDB {
        public DbSet<UserProfile> Profiles { get; set; }


    }

    public interface IDrunkSquadDB {
        DbSet<UserProfile> Profiles { get; }
    }

    public interface IUserDBAccess : IDBAccess<UserProfile> {
        UserProfile FindByID (int name);

        UserProfile FindByApiKey (string key);
    }
}
