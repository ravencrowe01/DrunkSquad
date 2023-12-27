using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Faction.Crimes {
    public interface ICrimeHandler {
        Task FetchMostRecentCrimesAsync (string key);

        IEnumerable<Crime> GetAllCrimes ();

        IEnumerable<Crime> GetCrimes (DateTime from, DateTime to);

        IEnumerable<Crime> GetCrimesForUser (int id, DateTime from, DateTime to);
    }
}
