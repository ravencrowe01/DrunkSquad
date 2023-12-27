using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public interface IFactionCrimeAccess : IEntityAccess<Crime> {
        void AddRange (IEnumerable<Crime> crimes);
    }
}
