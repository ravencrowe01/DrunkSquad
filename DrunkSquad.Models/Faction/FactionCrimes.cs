namespace DrunkSquad.Models.Faction {
    public class FactionCrimes {
        public IEnumerable<FactionCrime> Crimes { get; set; }

        public int TotalMoneyGained { get; set; }

        public int TotalRepGained { get; set; }

        public float SuccessRate { get; set; }
    }
}
