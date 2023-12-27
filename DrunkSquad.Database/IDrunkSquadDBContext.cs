﻿using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Common;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public interface IDrunkSquadDBContext {
        DbSet<Bar> Bars { get; }
        DbSet<Crime> Crimes { get; }
        DbSet<FactionStub> FactionStubs { get; }
        DbSet<Job> Jobs { get; }
        DbSet<LastAction> LastActions { get; }
        DbSet<LoginDetails> LoginDetails { get; }
        DbSet<Marriage> Marriages { get; }
        DbSet<Member> Members { get; }
        DbSet<PlayerStates> PlayerStates { get; }
        DbSet<Status> Statuses { get; }
        DbSet<User> Users { get; }
    }
}