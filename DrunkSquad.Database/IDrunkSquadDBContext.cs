using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database {
    public interface IDrunkSquadDBContext {
        DbSet<User> Users { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<FactionCrime> Crimes { get; }
        DbSet<Job> Jobs { get; }
        DbSet<LastAction> LastActions { get; }
        DbSet<PlayerStates> PlayerStates { get; }
        DbSet<Status> Statuses { get; }
        DbSet<LoginDetails> LoginDetails { get; }
        DbSet<Member> Members { get; }
        DbSet<FactionInfo> Factioninfo { get; }
        DbSet<Position> Positions { get; }
        DbSet<PositionMeta> PositionMetas { get; }
        DbSet<CrimeExperienceEntry> CrimeExperience { get; }
    }
}