using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class CrimeExperienceEntry {
        public int ID { get; set; }

        public Member Member { get; set; }

        public int Rank { get; set; }
    }
}
