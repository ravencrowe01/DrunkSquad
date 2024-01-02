using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionCrime : Crime {
        public IEnumerable<CrimeParticipant> CrimeParticipants { get; set; }
    }
}
