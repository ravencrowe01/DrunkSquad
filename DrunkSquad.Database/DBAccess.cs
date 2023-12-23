using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database {
    public class DBAccess : DbContext {
        public DbSet<DSUser> Users { get; set; }
        public UserAccess UserAccess => new UserAccess (Users);

        public DbSet<Crime> Crimes { get; set; }
    }
}
