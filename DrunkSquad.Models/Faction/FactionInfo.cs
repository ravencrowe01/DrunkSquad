using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionInfo {
        public Basic Basic { get; set; }

        public int ID { get; set; }

        public int FactionID { get; set; }

        public IEnumerable<Member> MembersList {
            get {
                if (_members is null || _members.Count < 1) {
                    foreach (var key in Basic.Members.Keys) {
                        Basic.Members [key].MemberID = int.Parse (key);
                    }

                    _members = Basic.Members.Values.ToList ();
                }

                return _members;
            }
            set {
                _members = (List<Member>) value;
            }
        }
        private List<Member> _members = new List<Member> ();
    }
}
