namespace DrunkSquad.Models.Faction {
    public class FactionCrimes {
        public IEnumerable<FactionCrime> Crimes { get; set; }

        public int TotalMoneyGained {
            get {
                var total = 0;

                foreach (var crime in Crimes) {
                    if (crime.Initiated) {
                        total += crime.MoneyGain;
                    }
                }

                return total;
            }
        }

        public int TotalRepGained {
            get {
                var total = 0;

                foreach (var crime in Crimes) {
                    if (crime.Initiated) {
                        total += crime.RespectGain;
                    }

                }

                return total;
            }
        }

        public float SuccessRate {
            get {
                var total = 0f;

                foreach (var crime in Crimes) {
                    if (crime.Initiated) {
                        total += crime.Success ? 1f : 0f;
                    };
                }

                return total / Crimes.Count();
            }
        }
    }
}
