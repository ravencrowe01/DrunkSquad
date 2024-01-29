using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction;

public class FactionCrimesOverview {
    public FactionCrimes Crimes { get; set; }

    public IDictionary<int, int> CERanks { get; set; }

    public IEnumerable<Member> Members { get; set; }

    public UserCrimes GetCrimesForUser(int id) => new UserCrimes { 
        Crimes = Crimes.Crimes.Where(crime => crime.ParticipantIDs.Contains(id))
    };
}