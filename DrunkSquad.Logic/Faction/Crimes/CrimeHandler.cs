using DrunkSquad.Database.Accessors;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Raven.Util;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public class CrimeHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionCrimeAccess crimeAccess, IMemberAccess memberAccess) : ICrimeHandler {
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

                var response = await apiClient.GetAsync<CrimesCollection> (requestConfig, TornApi.Net.Models.Key.AccessLevel.LimitedAccess);

                if (response is not null && response.IsValid ()) {
                    var crimes = response.Content;

                    if (crimes is not null) {
                        fetchedCrimes = ProcessCrimes (crimes);
                    }
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
                        var temp = new List<CrimeParticipant> ();

                        foreach (var participant in crime.Participants) {
                            temp.Add (new CrimeParticipant {
                                Crime = crime,
                                Participant = memberAccess.Set.FirstOrDefault(member => member.MemberID == participant)

                            });
                        };

                        crime.CrimeParticipants = temp;

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

                var factionCrime = Cloner.Clone<Crime, FactionCrime> (crime);

                factionCrime.CrimeID = int.Parse (crimeID);

                factionCrime.SetParticipants (memberAccess);

                factionCrimes.Add (factionCrime);
            }

            return factionCrimes;
        }

        public void AddFactionCrimes (IEnumerable<FactionCrime> crimes) => crimeAccess.AddRange (crimes);

        public FactionCrimes GetAllCrimes () => new FactionCrimes { Crimes = WithParticipants () };

        public FactionCrimes GetAllCrimes (DateTime from, DateTime to) {
            var found = WithParticipants ().Where (crime => crime.TimeStarted >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeStarted <= GetUnixTimestamp (to.ToUniversalTime ()));

            return new FactionCrimes {
                Crimes = found
            };
        }

        public FactionCrimes GetAllCrimes (long from, long to) {
            var found = WithParticipants ().Where (crime => crime.TimeStarted >= from && crime.TimeStarted <= to);

            return new FactionCrimes {
                Crimes = found
            };
        }

        public FactionCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to) {
            var found = WithParticipants ().Where (crime => crime.TimeStarted >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeStarted <= GetUnixTimestamp (to.ToUniversalTime ()) && crime.CrimeParticipants.Any (participant => participant.Participant.MemberID == id));

            return new FactionCrimes {
                Crimes = found
            };
        }

        public FactionCrimes GetAllCrimesForUser (int id, long from, long to) {
            var found = WithParticipants ().Where (crime => crime.TimeStarted >= from && crime.TimeStarted <= to);

            return new FactionCrimes {
                Crimes = found
            };
        }

        private IIncludableQueryable<FactionCrime, IEnumerable<CrimeParticipant>> WithParticipants () {
            var found = crimeAccess.Set.Include (crime => crime.CrimeParticipants);

            return found;
        }

        private static long GetUnixTimestamp (DateTime dateTime) {
            DateTime unixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeDifference = dateTime.ToUniversalTime () - unixEpoch;

            return (long) timeDifference.TotalSeconds;
        }
    }
}
