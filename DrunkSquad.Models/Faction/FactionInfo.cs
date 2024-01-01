using DrunkSquad.Models.Users;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionInfo : Basic {
        public IEnumerable<User> MembersList { 
            get {
                if(_members is null || _members.Count < 1) {
                    foreach(var key in Members.Keys) {
                        Members [key].MemberID = int.Parse (key);
                    }

                    _members = (List<User>) Members.Values;
                }

                return _members;
            } 
            set {
                _members = (List<User>) value;
            }
        }
        private List<User> _members = new List<User> ();

        public IEnumerable<int> MemberIDs { get; set; }

        public FactionInfo () { }
    }
}
