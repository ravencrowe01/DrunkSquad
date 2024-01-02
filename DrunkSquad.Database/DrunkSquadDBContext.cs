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

        public DbSet<FactionCrime> Crimes { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<LastAction> LastActions { get; set; }

        public DbSet<Bar> Bars { get; set; }

        public DbSet<Marriage> Marriages { get; set; }

        public DbSet<PlayerStates> PlayerStates { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<LoginDetails> LoginDetails { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<FactionInfo> Factioninfo { get;set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Job> ().HasKey (job => job.JobID).HasName ("JobID");

            builder.Entity<LastAction> ().HasKey (action => action.LastActionID).HasName ("LastActionID");

            builder.Entity<Bar> ().HasKey (bar => bar.BarID).HasName ("BarID");

            builder.Entity<Marriage> ().HasKey (marriage => marriage.MarriageID).HasName ("MarriageID");

            builder.Entity<PlayerStates> ().HasKey (states => states.PlayerStatesID).HasName ("PlayerStatesID");

            builder.Entity<Status> ().HasKey (status => status.StatusID).HasName ("ProfiStatusIDleID");

            builder.Entity<LoginDetails> ().HasKey (details => details.ID);

            builder.Entity<Member> ().HasKey (member => member.MemberID).HasName ("MemberID");

            BuildUser (builder);

            BuildFactionCrime (builder);

            BuildFactionInfo (builder);
        }

        private static void BuildUser (ModelBuilder builder) {
            builder.Entity<User> ().HasKey (user => user.ProfileID).HasName ("ProfileID");

            builder.Entity<User> ().HasOne (user => user.Job);
            builder.Entity<User> ().HasOne (user => user.LastAction);
            builder.Entity<User> ().HasOne (user => user.Life);
            builder.Entity<User> ().HasOne (user => user.States);
            builder.Entity<User> ().HasOne (user => user.Status);
            builder.Entity<User> ().HasOne (user => user.LoginDetails);

            builder.Entity<User> ().Ignore (user => user.Competition);
            builder.Entity<User> ().Ignore (user => user.BasicIcons);
            builder.Entity<User> ().Ignore (user => user.Faction);
        }

        private static void BuildFactionCrime (ModelBuilder builder) {
            builder.Entity<CrimeParticipant> ().HasKey (participant => participant.ID).HasName("CrimeParticipantID");

            builder.Entity<CrimeParticipant> ().HasOne (participant => participant.Crime);

            builder.Entity<CrimeParticipant> ().HasOne (participant => participant.Participant);

            builder.Entity<FactionCrime> ().HasKey (crime => crime.CrimeID).HasName ("FactionCrimeID");

            builder.Entity<FactionCrime> ().HasMany (crime => crime.CrimeParticipants);

            builder.Entity<FactionCrime> ().Ignore (crime => crime.Participants);
            builder.Entity<FactionCrime> ().Ignore (crime => crime.FactionID);
        }

        private static void BuildFactionInfo (ModelBuilder builder) {
            builder.Entity<FactionInfo> ().HasKey (faction => faction.ID).HasName ("FactionID");

            builder.Entity<FactionInfo> ().HasMany (faction => faction.MembersList);

            builder.Entity<FactionInfo> ().Ignore (faction => faction.Members);
        }
    }
}
