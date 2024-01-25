using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class PositionMeta {
        public int ID { get; set; }

        public Position Position { get; set; }

        public bool IsAdmin { get; set; }
    }
}
