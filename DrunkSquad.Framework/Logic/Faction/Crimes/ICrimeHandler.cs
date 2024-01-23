using DrunkSquad.Models.Faction;

namespace DrunkSquad.Framework.Logic.Faction.Crimes;

public interface ICrimeHandler {
    void AddFactionCrimes (IEnumerable<FactionCrime> crimes);
    FactionCrimes GetAllCrimes ();

    FactionCrimes GetAllCrimes (DateTime from, DateTime to);

    FactionCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to);

    Task<IEnumerable<FactionCrime>> FetchCrimesInRangeAsync (DateTime from, DateTime to);
}
