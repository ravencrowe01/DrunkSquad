using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Faction;

namespace DrunkSquad.Logic.Extensions {
    public static class FactionCrimeExtensions {
        public static void SetParticipants(this FactionCrime crime, IMemberAccess memberAccess) {
            var participants = new List<CrimeParticipant> ();

            foreach (var memberID in crime.Participants) {
                var found = memberAccess.FindByID (memberID);

                if(found is not null) {
                    var participant = new CrimeParticipant {
                        Crime = crime,
                        Participant = found
                    };

                    participants.Add (participant);
                }
            }

            crime.CrimeParticipants = participants;
        }

        public static string ParticipantsToString (this FactionCrime crime) {
            var participants = new List<string> ();

            foreach (var participant in crime.CrimeParticipants) {
                participants.Add (participant.Participant.Name);
            }

            return string.Join (',', participants);
        }
    }
}
