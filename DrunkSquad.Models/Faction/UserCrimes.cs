namespace DrunkSquad.Models.Faction {
    public class UserCrimes {
        public int UserID { get; set; }

        public string Username { get; set; }

        public IEnumerable<FactionCrime> Crimes { get; set; }

        public int TotalCrimes { get; set; }

        public int TotalMoneyGained { get; set; }

        public int TotalRespectGained { get; set; }

        public float SuccessRate { get; set; }
    }
}
