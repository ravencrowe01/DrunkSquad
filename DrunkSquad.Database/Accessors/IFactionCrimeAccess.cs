using DrunkSquad.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public interface IFactionCrimeAccess : IEntityAccess<FactionCrime> {
        FactionCrime FindByCrimeID (int id);
    }
}
