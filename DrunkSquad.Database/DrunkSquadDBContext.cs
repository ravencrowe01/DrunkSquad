﻿using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public class DrunkSquadDBContext (DbContextOptions<DrunkSquadDBContext> options) : DbContext (options), IDrunkSquadDBContext {
        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<CrimeParticipant> CrimeParticipants { get; set; }

        public DbSet<FactionCrime> Crimes { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<LastAction> LastActions { get; set; }

        public DbSet<Marriage> Marriages { get; set; }

        public DbSet<PlayerStates> PlayerStates { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<LoginDetails> LoginDetails { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Basic> Basic { get; set; }

        public DbSet<FactionInfo> Factioninfo { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Job> ().HasKey (job => job.ID);

            builder.Entity<LastAction> ().HasKey (action => action.ID);

            builder.Entity<Marriage> ().HasKey (marriage => marriage.ID);

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
        }

        private static void BuildUserModel (ModelBuilder builder) {
            builder.Entity<User> ().HasKey (user => user.ID);

            builder.Entity<User> ().HasOne (user => user.Profile);
            builder.Entity<User> ().HasOne (user => user.LoginDetails);
        }

        private static void BuildFactionCrimeModel (ModelBuilder builder) {
            builder.Entity<CrimeParticipant> ().HasKey (participant => participant.ID);

            builder.Entity<CrimeParticipant> ().HasOne (participant => participant.Crime);

            builder.Entity<CrimeParticipant> ().HasOne (participant => participant.Participant);

            builder.Entity<Crime> ().HasKey (crime => crime.ID).HasName ("FactionCrimeID");

            builder.Entity<FactionCrime> ().HasMany (crime => crime.CrimeParticipants);

            builder.Entity<Crime> ().Ignore (crime => crime.Participants);
            builder.Entity<Crime> ().Ignore (crime => crime.Faction);
        }

        private static void BuildFactionInfoModel (ModelBuilder builder) {
            builder.Entity<FactionInfo> ().HasKey (faction => faction.ID);

            builder.Entity<FactionInfo> ().HasOne (faction => faction.Basic);

            builder.Entity<FactionInfo> ().HasMany (faction => faction.MembersList);

            builder.Entity<Basic> ().HasKey (basic => basic.ID);

            builder.Entity<Basic> ().Ignore (faction => faction.Members);
            builder.Entity<Basic> ().Ignore (faction => faction.Rank);
        }
    }
}
