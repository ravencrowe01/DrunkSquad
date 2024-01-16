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
                if (_participantIDs is null || _participantIDs.Count () < 1) {
                    var participants = Participants.Split (',');

                    var _participantIDs = new List<int> ();

                    foreach (var particpant in participants) {
                        _participantIDs.Add (int.Parse (particpant));
                    }
                }

                return _participantIDs;
            }
        }

        private IEnumerable<int> _participantIDs;

        public bool HasParticipant (int id) => Participants.Split (',').ToList ().Contains (id.ToString ());
    }
}
