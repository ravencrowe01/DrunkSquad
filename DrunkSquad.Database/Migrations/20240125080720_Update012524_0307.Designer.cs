﻿// <auto-generated />
using System;
using DrunkSquad.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrunkSquad.Database.Migrations
{
    [DbContext(typeof(DrunkSquadDBContext))]
    [Migration("20240125080720_Update012524_0307")]
    partial class Update012524_0307
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionCrime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CrimeID")
                        .HasColumnType("int");

                    b.Property<int>("CrimeType")
                        .HasColumnType("int");

                    b.Property<bool>("Initiated")
                        .HasColumnType("bit");

                    b.Property<int>("InitiatedBy")
                        .HasColumnType("int");

                    b.Property<int>("MoneyGain")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Participants")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlannedBy")
                        .HasColumnType("int");

                    b.Property<int>("RespectGain")
                        .HasColumnType("int");

                    b.Property<bool>("Success")
                        .HasColumnType("bit");

                    b.Property<long>("TimeComplete")
                        .HasColumnType("bigint");

                    b.Property<int>("TimeLeft")
                        .HasColumnType("int");

                    b.Property<long>("TimeReady")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeStarted")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Crimes");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BestChain")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("ColeaderID")
                        .HasColumnType("int");

                    b.Property<int>("FactionID")
                        .HasColumnType("int");

                    b.Property<int>("LeaderID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Respect")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Factioninfo");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.PositionMeta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int?>("PositionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PositionID");

                    b.ToTable("PositionMetas");
                });

            modelBuilder.Entity("DrunkSquad.Models.Users.LoginDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("LoginDetails");
                });

            modelBuilder.Entity("DrunkSquad.Models.Users.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("LoginDetailsID")
                        .HasColumnType("int");

                    b.Property<int?>("PositionID")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileID")
                        .HasColumnType("int");

                    b.Property<int>("WebsiteRole")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LoginDetailsID");

                    b.HasIndex("PositionID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TornApi.Net.Models.Faction.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DaysInFaction")
                        .HasColumnType("int");

                    b.Property<int>("FactionID")
                        .HasColumnType("int");

                    b.Property<int?>("FactionInfoID")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FactionInfoID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("TornApi.Net.Models.Faction.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CanAccessFactionApi")
                        .HasColumnType("int");

                    b.Property<int>("CanAdjustMemberBalance")
                        .HasColumnType("int");

                    b.Property<int>("CanChangeAnnouncement")
                        .HasColumnType("int");

                    b.Property<int>("CanChangeDescription")
                        .HasColumnType("int");

                    b.Property<int>("CanGiveItem")
                        .HasColumnType("int");

                    b.Property<int>("CanGiveMoney")
                        .HasColumnType("int");

                    b.Property<int>("CanGivePoints")
                        .HasColumnType("int");

                    b.Property<int>("CanKickMembers")
                        .HasColumnType("int");

                    b.Property<int>("CanLoanTemporaryItem")
                        .HasColumnType("int");

                    b.Property<int>("CanLoanWeaponAndArmory")
                        .HasColumnType("int");

                    b.Property<int>("CanManageApplications")
                        .HasColumnType("int");

                    b.Property<int>("CanManageForum")
                        .HasColumnType("int");

                    b.Property<int>("CanManageUpgrades")
                        .HasColumnType("int");

                    b.Property<int>("CanManageWars")
                        .HasColumnType("int");

                    b.Property<int>("CanPlanAndInitiateOrganisedCrime")
                        .HasColumnType("int");

                    b.Property<int>("CanRetrieveLoanedArmory")
                        .HasColumnType("int");

                    b.Property<int>("CanSendNewsletter")
                        .HasColumnType("int");

                    b.Property<int>("CanUseBoosterItem")
                        .HasColumnType("int");

                    b.Property<int>("CanUseDrugItem")
                        .HasColumnType("int");

                    b.Property<int>("CanUseEnergyRefill")
                        .HasColumnType("int");

                    b.Property<int>("CanUseMedicalItem")
                        .HasColumnType("int");

                    b.Property<int>("CanUseNerveRefill")
                        .HasColumnType("int");

                    b.Property<int>("Default")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.LastAction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("LastActionID")
                        .HasColumnType("int");

                    b.Property<string>("Relative")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("LastActions");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Marriage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MarriageID")
                        .HasColumnType("int");

                    b.Property<int>("SpouseID")
                        .HasColumnType("int");

                    b.Property<string>("SpouseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Marriages");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.PlayerStates", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<long>("HospitalTimestamp")
                        .HasColumnType("bigint");

                    b.Property<long>("JailTimestamp")
                        .HasColumnType("bigint");

                    b.Property<int>("PlayerStatesID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PlayerStates");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Awards")
                        .HasColumnType("int");

                    b.Property<bool>("Donator")
                        .HasColumnType("bit");

                    b.Property<int>("Enemies")
                        .HasColumnType("int");

                    b.Property<int>("ForumPosts")
                        .HasColumnType("int");

                    b.Property<int>("Friends")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Honor")
                        .HasColumnType("int");

                    b.Property<int?>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("Karma")
                        .HasColumnType("int");

                    b.Property<int?>("LastActionID")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileID")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Revivable")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Signup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatesID")
                        .HasColumnType("int");

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JobID");

                    b.HasIndex("LastActionID");

                    b.HasIndex("StatesID");

                    b.HasIndex("StatusID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<long>("Until")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.PositionMeta", b =>
                {
                    b.HasOne("TornApi.Net.Models.Faction.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("DrunkSquad.Models.Users.User", b =>
                {
                    b.HasOne("DrunkSquad.Models.Users.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginDetailsID");

                    b.HasOne("TornApi.Net.Models.Faction.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");

                    b.HasOne("TornApi.Net.Models.User.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.Navigation("LoginDetails");

                    b.Navigation("Position");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TornApi.Net.Models.Faction.Member", b =>
                {
                    b.HasOne("DrunkSquad.Models.Faction.FactionInfo", null)
                        .WithMany("Members")
                        .HasForeignKey("FactionInfoID");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Profile", b =>
                {
                    b.HasOne("TornApi.Net.Models.User.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID");

                    b.HasOne("TornApi.Net.Models.User.LastAction", "LastAction")
                        .WithMany()
                        .HasForeignKey("LastActionID");

                    b.HasOne("TornApi.Net.Models.User.PlayerStates", "States")
                        .WithMany()
                        .HasForeignKey("StatesID");

                    b.HasOne("TornApi.Net.Models.User.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");

                    b.Navigation("Job");

                    b.Navigation("LastAction");

                    b.Navigation("States");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionInfo", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
