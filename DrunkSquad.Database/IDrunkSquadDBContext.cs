﻿using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public interface IDrunkSquadDBContext {
        DbSet<FactionCrime> Crimes { get; }
        DbSet<Job> Jobs { get; }
        DbSet<LastAction> LastActions { get; }
        DbSet<LoginDetails> LoginDetails { get; }
        DbSet<Marriage> Marriages { get; }
        DbSet<Member> Members { get; }
        DbSet<PlayerStates> PlayerStates { get; }
        DbSet<Status> Statuses { get; }
        DbSet<User> Users { get; }
        DbSet<Basic> Basic { get; set; }
    }
}