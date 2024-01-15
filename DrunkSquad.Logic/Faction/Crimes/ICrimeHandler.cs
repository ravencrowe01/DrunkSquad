using DrunkSquad.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public interface ICrimeHandler {
        void AddFactionCrimes (IEnumerable<FactionCrime> crimes);
        Task<IApiResponse<CrimesCollection>> FetchMostRecentCrimesAsync ();

        FactionCrimes GetAllCrimes ();

        FactionCrimes GetAllCrimes (DateTime from, DateTime to);

        FactionCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to);

        Task<IEnumerable<FactionCrime>> FetchCrimesInRangeAsync (string key, DateTime from, DateTime to);
    }
}
