using DrunkSquad.Models.Users;

namespace DrunkSquad.Models.Faction {
    public class FactionCrime {
        public int FactionID { get; set; }

        public int FactionCrimeID { get; set; }

        public int CrimeType { get; set; }

        public string Name { get; set; }

        public bool Initiated { get; set; }

        public int InitiatedBy { get; set; }

        public int MoneyGain { get; set; }

        public IEnumerable<User> Participants { get; set; }

        public int PlannedBy { get; set; }

        public int RespectGain { get; set; }

        public bool Success { get; set; }

        public long TimeComplete { get; set; }

        public int TimeLeft { get; set; }

        public long TimeReady { get; set; }

        public long TimeCreated { get; set; }
    }
}
