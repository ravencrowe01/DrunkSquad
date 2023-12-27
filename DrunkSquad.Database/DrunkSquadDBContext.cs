using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Common;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public class DrunkSquadDBContext (DbContextOptions<DrunkSquadDBContext> options) : DbContext (options), IDrunkSquadDBContext {
        public DbSet<User> Users { get; set; }

        public DbSet<CrimeParticipant> CrimeParticipants { get; set; }

        public DbSet<Crime> Crimes { get; set; }

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
            builder.Entity<Job> ().HasKey (job => job.ID);

            builder.Entity<LastAction> ().HasKey (action => action.ID);

            builder.Entity<Bar> ().HasKey (bar => bar.ID);

            builder.Entity<Marriage> ().HasKey (marriage => marriage.ID);

            builder.Entity<PlayerStates> ().HasKey (states => states.ID);

            builder.Entity<Status> ().HasKey (status => status.ID);

            builder.Entity<FactionStub> ().HasKey (stub => stub.FactionID);

            builder.Entity<LoginDetails> ().HasKey (details => details.ID);

            builder.Entity<Member> ().HasKey (member => member.ID);

            builder.Entity<User> ().HasKey (user => user.ID);

            builder.Entity<User> ().HasOne (user => user.Job);
            builder.Entity<User> ().HasOne (user => user.LastAction);
            builder.Entity<User> ().HasOne (user => user.Life);
            builder.Entity<User> ().HasOne (user => user.States);
            builder.Entity<User> ().HasOne (user => user.Status);
            builder.Entity<User> ().HasOne (user => user.LoginDetails);

            builder.Entity<User> ().Ignore (user => user.Competition);
            builder.Entity<User> ().Ignore (user => user.BasicIcons);

            builder.Entity<Crime> ().HasKey (crime => crime.ID);

            builder.Entity<Crime> ().HasMany (Crime => Crime.Participants);

        }
    }
}
