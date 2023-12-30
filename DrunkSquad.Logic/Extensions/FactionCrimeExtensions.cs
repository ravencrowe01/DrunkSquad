using DrunkSquad.Models.Faction;

namespace DrunkSquad.Logic.Extensions {
    public static class FactionCrimeExtensions {
        public static string ParticipantsToString (this FactionCrime crime) {
            var participants = new List<string> ();

            foreach (var participant in crime.Participants) {
                participants.Add (participant.Name);
            }

            return string.Join (',', participants);
        }
    }
}
