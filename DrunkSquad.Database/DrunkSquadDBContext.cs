using DrunkSquad.Models.Config;
using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Common;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public class DrunkSquadDBContext (DbContextOptions<DrunkSquadDBContext> options) : DbContext(options), IDrunkSquadDBAccess {
        public DbSet<DSUser> Users { get; set; }
        public IUserAccess UserAccess {
            get {
                if (_userAccess == null) {
                    _userAccess = new UserAccess (Users, this);
                }

                return _userAccess;
            }
        }
        private UserAccess _userAccess = null;

        public DbSet<Crime> Crimes { get; set; }
        public IEntityAccess<Crime> CrimeAccess {
            get {
                if (_crimeAccess == null) {
                    _crimeAccess = new EntityAccess<Crime> (Crimes, this);
                }

                return _crimeAccess;
            }
        }
        private IEntityAccess<Crime> _crimeAccess = null;

        public DbSet<Job> Jobs { get; set; }

        public DbSet<LastAction> LastActions { get; set; }

        public DbSet<Bar> Bars { get; set; }

        public DbSet<Marriage> Marriages { get; set; }

        public DbSet<PlayerStates> PlayerStates { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<FactionStub> FactionStubs { get; set; }

        public DbSet<LoginDetails> LoginDetails { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Job> ().HasKey(job => job.ID);

            builder.Entity<LastAction> ().HasKey (action => action.ID);

            builder.Entity<Bar> ().HasKey (bar => bar.ID);

            builder.Entity<Marriage> ().HasKey (marriage => marriage.ID);

            builder.Entity<PlayerStates> ().HasKey (states => states.ID);

            builder.Entity<Status> ().HasKey (status => status.ID);

            builder.Entity<FactionStub> ().HasKey (stub => stub.FactionID);

            builder.Entity<LoginDetails> ().HasKey (details => details.ID);

            builder.Entity<Member> ().HasKey (member => member.ID);

            builder.Entity<DSUser> ().HasKey (user => user.ID);

            builder.Entity<DSUser> ().HasOne (user => user.Job);
            builder.Entity<DSUser> ().HasOne (user => user.LastAction);
            builder.Entity<DSUser> ().HasOne (user => user.Life);
            builder.Entity<DSUser> ().HasOne (user => user.States);
            builder.Entity<DSUser> ().HasOne (user => user.Status);
            builder.Entity<DSUser> ().HasOne (user => user.LoginDetails);

            builder.Entity<DSUser> ().Ignore (user => user.Competition);
            builder.Entity<DSUser> ().Ignore (user => user.BasicIcons);
        }
    }
}
