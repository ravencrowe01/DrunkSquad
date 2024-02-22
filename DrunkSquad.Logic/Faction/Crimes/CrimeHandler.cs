using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public class CrimeHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionCrimeAccess crimeAccess, IProfileAccess profileAccess) : ICrimeHandler {
        public async Task<IEnumerable<FactionCrime>> FetchCrimesInRangeAsync (DateTime from, DateTime to) {
            var fromCurrent = from;
            var toCurrent = fromCurrent.AddDays (7) > to ? fromCurrent.AddDays (7) : to;

            var factionCrimes = new List<FactionCrime> ();

            do {
                var requestConfig = new RequestConfiguration {
                    Key = config.Api.DefaultKey,
                    Section = "faction",
                    Selections = ["crimes"],
                    Comment = "Drunk Squad Crimes Fetch",
                    From = fromCurrent.ToUniversalTime (),
                    To = toCurrent.ToUniversalTime ()
                };

                var fetchedCrimes = new List<FactionCrime> ();

                var response = await apiClient.GetAsync<CrimesCollection> (requestConfig, config.Api.RequiredAccessLevel);

                if (response is not null && response.IsValid ()) {
                    var crimes = response.Content;

                    if (crimes is not null) {
                        fetchedCrimes = ProcessCrimes (crimes);
                    }
                }
                else {
                    continue;
                }

                if (fetchedCrimes.Count > 0) {
                    fetchedCrimes = fetchedCrimes.OrderByDescending (crime => crime.TimeStarted).ToList ();

                    var lastDate = DateTimeOffset.FromUnixTimeSeconds (fetchedCrimes.First ().TimeStarted);

                    fromCurrent = lastDate.UtcDateTime.AddSeconds (10);
                }
                else {
                    fromCurrent = fromCurrent.AddDays (1) < to ? fromCurrent.AddDays (1) : to;
                }

                toCurrent = fromCurrent.AddDays (1) < to ? fromCurrent.AddDays (1) : to;

                fetchedCrimes.ForEach (crime => {
                    if (!factionCrimes.Any (c => c.CrimeID == crime.CrimeID)) {
                        factionCrimes.Add (crime);
                    }
                });
            }
            while (fromCurrent < to);

            return factionCrimes;
        }

        private static List<FactionCrime> ProcessCrimes (CrimesCollection unprocessedCrimes) {
            var temp = new List<FactionCrime> ();

            foreach (var pair in unprocessedCrimes.Crimes) {
                var id = pair.Key;
                var crime = pair.Value;
                crime.CrimeID = int.Parse (id);

                temp.Add (crime.ToFactionCrime ());
            }

            return temp;
        }

        private List<FactionCrime> ConstructFactionCrimes (IDictionary<string, Crime> crimes) {
            var factionCrimes = new List<FactionCrime> ();

            foreach (var crimeID in crimes.Keys) {
                var crime = crimes [crimeID];

                var factionCrime = crime.ToFactionCrime ();

                factionCrime.CrimeID = int.Parse (crimeID);

                factionCrimes.Add (factionCrime);
            }

            return factionCrimes;
        }

        public void AddFactionCrime (FactionCrime crime) {
            var found = crimeAccess.FindByCrimeID (crime.CrimeID);
            if (found is null) {
                crimeAccess.Add (crime);
            }
            else {
                crime.ID = found.ID;

                crimeAccess.UpdateCrime (crime);
            }
        }

        public void AddFactionCrimes (IEnumerable<FactionCrime> crimes) => crimes.ToList ().ForEach (AddFactionCrime);

        public FactionCrimes GetAllCrimes () {
            var crimes = crimeAccess.Set.ToList ();

            foreach (var crime in crimes) {
                var participantIDs = crime.ParticipantIDs;

                var participantNames = new List<string> ();

                foreach (var participantID in participantIDs) {
                    var profile = profileAccess.FindByProfileID (participantID);

                    if (profile is not null) {
                        var name = profile.Name;

                        participantNames.Add (name);
                    }
                    else {
                        participantNames.Add ("<unavailable>");
                    }
                }

                crime.ParticipantNames = participantNames;
            }

            var factionCrimes = new FactionCrimes {
                Crimes = crimes
            };

            return factionCrimes;
        }

        public FactionCrimes GetAllCrimes (DateTime from, DateTime to) {
            var found = crimeAccess.Set.Where (crime => crime.TimeStarted >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeStarted <= GetUnixTimestamp (to.ToUniversalTime ()));

            return new FactionCrimes {
                Crimes = found
            };
        }

        public FactionCrimes GetAllCrimes (long from, long to) {
            var found = crimeAccess.Set.Where (crime => crime.TimeStarted >= from && crime.TimeStarted <= to);

            return new FactionCrimes {
                Crimes = found
            };
        }

        public UserCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to) {
            var found = crimeAccess.Set.Where (crime => crime.TimeStarted >= GetUnixTimestamp (from.ToUniversalTime ())
                                        && crime.TimeStarted <= GetUnixTimestamp (to.ToUniversalTime ()))
                .AsEnumerable ()
                .Where (crime => crime.HasParticipant (id))
                .ToList ();
            return new UserCrimes {
                Crimes = found
            };
        }

        private static long GetUnixTimestamp (DateTime dateTime) {
            DateTime unixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeDifference = dateTime.ToUniversalTime () - unixEpoch;

            return (long) timeDifference.TotalSeconds;
        }
    }
}
