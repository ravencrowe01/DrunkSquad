using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public class DrunkSquadDBContext : DbContext, IDrunkSquadDBContext {
        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<FactionCrime> Crimes { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<LastAction> LastActions { get; set; }

        public DbSet<PlayerStates> PlayerStates { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<LoginDetails> LoginDetails { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<FactionInfo> Factioninfo { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PositionMeta> PositionMetas { get; set; }

        public DbSet<CrimeExperienceEntry> CrimeExperience { get; set; }

        public DbSet<WorkingStats> WorkingStats { get; set; }

        public DbSet<BattleStats> BattleStats { get; set; }

        public DrunkSquadDBContext () { }

        public DrunkSquadDBContext (DbContextOptions<DrunkSquadDBContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Job> ().HasKey (job => job.ID);

            builder.Entity<LastAction> ().HasKey (action => action.ID);

            builder.Entity<PlayerStates> ().HasKey (states => states.ID);

            builder.Entity<Status> ().HasKey (status => status.ID);

            builder.Entity<LoginDetails> ().HasKey (details => details.ID);

            builder.Entity<Member> ().HasKey (member => member.ID);

            builder.Entity<Member> ().Ignore (member => member.LastAction);
            builder.Entity<Member> ().Ignore (member => member.Status);

            BuildProfileModel (builder);

            BuildUserModel (builder);

            BuildFactionCrimeModel (builder);

            BuildFactionInfoModel (builder);

            builder.Entity<Position> ().HasKey (position => position.ID);

            builder.Entity<PositionMeta> ().HasKey (meta => meta.ID);
            builder.Entity<PositionMeta> ().HasOne (meta => meta.Position);

            builder.Entity<CrimeExperienceEntry> ().HasKey (entry => entry.ID);

            builder.Entity<CrimeExperienceEntry> ().HasOne (entry => entry.Member);

            builder.Entity<WorkingStats> ().HasKey (stats => stats.ID);

            builder.Entity<BattleStats> ().HasKey (stats => stats.ID);

            builder.Entity<BattleStats> ().Ignore (stats => stats.StrengthInfo);
            builder.Entity<BattleStats> ().Ignore (stats => stats.DefenseInfo);
            builder.Entity<BattleStats> ().Ignore (stats => stats.DexterityInfo);
            builder.Entity<BattleStats> ().Ignore (stats => stats.SpeedInfo);
        }

        private static void BuildProfileModel (ModelBuilder builder) {
            builder.Entity<Profile> ().HasKey (user => user.ID);

            builder.Entity<Profile> ().HasOne (user => user.Job);
            builder.Entity<Profile> ().HasOne (user => user.LastAction);


            builder.Entity<Profile> ().HasOne (user => user.States);
            builder.Entity<Profile> ().HasOne (user => user.Status);

            builder.Entity<Profile> ().Ignore (user => user.Competition);
            builder.Entity<Profile> ().Ignore (user => user.BasicIcons);
            builder.Entity<Profile> ().Ignore (user => user.Faction);
            builder.Entity<Profile> ().Ignore (user => user.Life);
            builder.Entity<Profile> ().Ignore (user => user.Faction);
            builder.Entity<Profile> ().Ignore (user => user.Marriage);
        }

        private static void BuildUserModel (ModelBuilder builder) {
            builder.Entity<User> ().HasKey (user => user.ID);

            builder.Entity<User> ().HasOne (user => user.Profile);
            builder.Entity<User> ().HasOne (user => user.LoginDetails);
            builder.Entity<User> ().HasOne (user => user.BattleStats);
            builder.Entity<User> ().HasOne (user => user.WorkingStats);

            builder.Entity<User> ().Ignore (user => user.Crimes);
        }

        private static void BuildFactionCrimeModel (ModelBuilder builder) {
            builder.Entity<FactionCrime> ().HasKey (crime => crime.ID);

            builder.Entity<FactionCrime> ().Ignore (crime => crime.ParticipantNames);
            builder.Entity<FactionCrime> ().Ignore (crime => crime.ParticipantIDs);
        }

        private static void BuildFactionInfoModel (ModelBuilder builder) {
            builder.Entity<FactionInfo> ().HasKey (faction => faction.ID);

            builder.Entity<FactionInfo> ().HasMany (faction => faction.Members);
        }
    }
}
