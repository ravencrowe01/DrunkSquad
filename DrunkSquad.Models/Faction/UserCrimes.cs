using DrunkSquad.Models.Users;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Faction;

public class UserCrimes : FactionCrimes {
    public int UserID { get; set; }

    public string Username { get; set; }

    public FactionCrime CurrentOC => Crimes.OrderByDescending (crime => crime.TimeStarted).ToList()[0];

    public CriminalRecord CriminalRecord { get; set; }

    public UserCrimesStats CrimeStats { get; set; }
}

