using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionInfo : Basic {
        public IEnumerable<Member> MembersList {
            get {
                if (_members is null || _members.Count < 1) {
                    foreach (var key in Members.Keys) {
                        Members [key].MemberID = int.Parse (key);
                    }

                    _members = Members.Values.ToList ();
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
