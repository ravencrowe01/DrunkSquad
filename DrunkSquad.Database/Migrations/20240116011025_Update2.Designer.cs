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
    [Migration("20240116011025_Update2")]
    partial class Update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrunkSquad.Models.Faction.CrimeParticipant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CrimeID")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CrimeID");

                    b.HasIndex("ParticipantID");

                    b.ToTable("CrimeParticipants");
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

            modelBuilder.Entity("DrunkSquad.Models.Users.LoginDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ApiKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
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

                    b.Property<int?>("ProfileID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("WebsiteRole")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LoginDetailsID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TornApi.Net.Models.Faction.Crime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CrimeID")
                        .HasColumnType("int");

                    b.Property<int>("CrimeType")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("Initiated")
                        .HasColumnType("bit");

                    b.Property<int>("InitiatedBy")
                        .HasColumnType("int");

                    b.Property<int>("MoneyGain")
                        .HasColumnType("int");

                    b.Property<string>("Name")
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

                    b.HasKey("ID")
                        .HasName("FactionCrimeID");

                    b.ToTable("Crime");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Crime");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("TornApi.Net.Models.User.Bar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BarID")
                        .HasColumnType("int");

                    b.Property<int>("Current")
                        .HasColumnType("int");

                    b.Property<int>("Fulltime")
                        .HasColumnType("int");

                    b.Property<int>("Increment")
                        .HasColumnType("int");

                    b.Property<int>("Interval")
                        .HasColumnType("int");

                    b.Property<int>("Maximum")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileID")
                        .HasColumnType("int");

                    b.Property<int>("Ticktime")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Bar");
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

                    b.Property<int?>("MarriageID")
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

                    b.HasIndex("MarriageID");

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

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionCrime", b =>
                {
                    b.HasBaseType("TornApi.Net.Models.Faction.Crime");

                    b.HasDiscriminator().HasValue("FactionCrime");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.CrimeParticipant", b =>
                {
                    b.HasOne("DrunkSquad.Models.Faction.FactionCrime", "Crime")
                        .WithMany("CrimeParticipants")
                        .HasForeignKey("CrimeID");

                    b.HasOne("TornApi.Net.Models.Faction.Member", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantID");

                    b.Navigation("Crime");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("DrunkSquad.Models.Users.User", b =>
                {
                    b.HasOne("DrunkSquad.Models.Users.LoginDetails", "LoginDetails")
                        .WithMany()
                        .HasForeignKey("LoginDetailsID");

                    b.HasOne("TornApi.Net.Models.User.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.Navigation("LoginDetails");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TornApi.Net.Models.Faction.Member", b =>
                {
                    b.HasOne("DrunkSquad.Models.Faction.FactionInfo", null)
                        .WithMany("Members")
                        .HasForeignKey("FactionInfoID");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Bar", b =>
                {
                    b.HasOne("TornApi.Net.Models.User.Profile", null)
                        .WithMany("Bars")
                        .HasForeignKey("ProfileID");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Profile", b =>
                {
                    b.HasOne("TornApi.Net.Models.User.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobID");

                    b.HasOne("TornApi.Net.Models.User.LastAction", "LastAction")
                        .WithMany()
                        .HasForeignKey("LastActionID");

                    b.HasOne("TornApi.Net.Models.User.Marriage", "Marriage")
                        .WithMany()
                        .HasForeignKey("MarriageID");

                    b.HasOne("TornApi.Net.Models.User.PlayerStates", "States")
                        .WithMany()
                        .HasForeignKey("StatesID");

                    b.HasOne("TornApi.Net.Models.User.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");

                    b.Navigation("Job");

                    b.Navigation("LastAction");

                    b.Navigation("Marriage");

                    b.Navigation("States");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionInfo", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("TornApi.Net.Models.User.Profile", b =>
                {
                    b.Navigation("Bars");
                });

            modelBuilder.Entity("DrunkSquad.Models.Faction.FactionCrime", b =>
                {
                    b.Navigation("CrimeParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
