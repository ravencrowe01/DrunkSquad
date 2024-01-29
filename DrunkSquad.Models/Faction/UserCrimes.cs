namespace DrunkSquad.Models.Faction;

public class UserCrimes : FactionCrimes {
    public int UserID { get; set; }

    public string Username { get; set; }

    public FactionCrime CurrentOC => Crimes.OrderBy (crime => crime.TimeStarted).ToList()[0];
}

