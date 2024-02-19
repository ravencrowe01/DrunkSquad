namespace DrunkSquad.Models.Faction {
    public class FactionCrime {
        public int ID { get; set; }

        public int CrimeID { get; set; }

        public int CrimeType { get; set; }

        public string Name { get; set; }

        public bool Initiated { get; set; }

        public int InitiatedBy { get; set; }

        public int MoneyGain { get; set; }

        public string Participants { get; set; }

        public int PlannedBy { get; set; }

        public int RespectGain { get; set; }

        public bool Success { get; set; }

        public long TimeComplete { get; set; }

        public int TimeLeft { get; set; }

        public long TimeReady { get; set; }

        public long TimeStarted { get; set; }

        public IEnumerable<string> ParticipantNames { get; set; }

        public IEnumerable<int> ParticipantIDs {
            get {
                    var participants = Participants.Split (',');

                    var participantIDs = new List<int> ();

                    foreach (var particpant in participants) {
                        participantIDs.Add (int.Parse (particpant));
                    }

                    return participantIDs;
            }
        }

        public string CurrentStateString {
            get {
                if (Initiated) {
                    if (Success) {
                        return "Succeed";
                    }
                    else {
                        return "Failed";
                    }
                }
                else {
                    var readyTimeOffset = DateTimeOffset.FromUnixTimeSeconds (TimeReady);
                    var readyTime = readyTimeOffset.UtcDateTime;

                    if (DateTime.UtcNow < readyTime) {
                        return "Not Ready";
                    }
                    else {
                        return "Ready";
                    }
                }
            }
        }

        public bool HasParticipant (int id) => Participants.Split (',').ToList ().Contains (id.ToString ());

        public void Update (FactionCrime factionCrime) {
            CrimeID = factionCrime.CrimeID;
            CrimeType = factionCrime.CrimeType;
            Name = factionCrime.Name;
            Initiated = factionCrime.Initiated;
            InitiatedBy = factionCrime.InitiatedBy;
            MoneyGain = factionCrime.MoneyGain;
            Participants = factionCrime.Participants;
            PlannedBy = factionCrime.PlannedBy;
            RespectGain = factionCrime.RespectGain;
            Success = factionCrime.Success;
            TimeComplete = factionCrime.TimeComplete;
            TimeLeft = factionCrime.TimeLeft;
            TimeReady = factionCrime.TimeReady;
            TimeStarted = factionCrime.TimeStarted;
            ParticipantNames = factionCrime.ParticipantNames;
        }
    }
}
