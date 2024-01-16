using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionInfo {
        public int ID { get; set; }

        public int Age { get; set; }

        public int BestChain { get; set; }

        public int Capacity { get; set; }

        public int ColeaderID { get; set; }

        public int FactionID { get; set; }

        public int LeaderID { get; set; }

        public IEnumerable<Member> Members { get; set; }

        public string Name { get; set; }

        public int Respect { get; set; }

        public string Tag { get; set; }

        public string TagImage { get; set; }
    }
}
