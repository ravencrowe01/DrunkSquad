using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Faction.Crimes {
    public interface ICrimeHandler {
        Task FetchMostRecentCrimesAsync (string key);

        FactionCrimes GetAllCrimes ();

        FactionCrimes GetAllCrimes (DateTime from, DateTime to);

        FactionCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to);
    }
}
