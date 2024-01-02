using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class CrimeParticipant {
        public int ID { get; set; }

        public FactionCrime Crime { get; set; }

        public Member Participant { get; set; }
    }
}
