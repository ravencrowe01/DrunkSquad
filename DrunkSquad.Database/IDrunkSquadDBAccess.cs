using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database {
    public interface IDrunkSquadDBAccess {
        IEntityAccess<Crime> CrimeAccess { get; }
        IUserAccess UserAccess { get; }
    }
}