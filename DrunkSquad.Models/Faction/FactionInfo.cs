using DrunkSquad.Models.Users;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionInfo : Basic {
        public new IEnumerable<User> Members { 
            get {
                if(_members is null || _members.Count < 1) {
                    var dict = base.Members;

                    foreach(var key in dict.Keys) {
                        dict [key].MemberID = int.Parse (key);
                    }

                    _members = (List<User>) dict.Values;
                }

                return _members;
            } 
            set {
                _members = (List<User>) value;
            }
        }

        private List<User> _members = new List<User> ();
    }
}
