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
        public async Task<IApiResponse<CrimesCollection>> FetchMostRecentCrimesAsync () {
            // TODO Needs to pull the last 30 days of crimes.
            RequestConfiguration reqConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                Section = "faction",
                Selections = ["crimes"],
                Comment = "Drunk Squad Crimes Fetch",
            };

            var response = await apiClient.GetAsync<CrimesCollection> (reqConfig,
            config.Api.RequiredAccessLevel);

            return response;
        }

        public async Task<IEnumerable<FactionCrime>> FetchCrimesInRangeAsync (string key, DateTime from, DateTime to) {
            var factionCrimes = new List<FactionCrime> ();

            var fromCurrent = from;
            var toCurrent = fromCurrent.AddDays (1) <= to ? fromCurrent.AddDays (1) : to;

            do {
                var reqConfig = new RequestConfiguration {
                    Key = key,
                    Section = "faction",
                    Selections = ["crimes"],
                    Comment = "Drunk Squad Crimes Fetch",
                    From = fromCurrent,
                    To = toCurrent
                };

                var response = await apiClient.GetAsync<CrimesCollection> (reqConfig, config.Api.RequiredAccessLevel);

                var content = response.Content.Crimes;

                if (response is not null) {
                    
                    factionCrimes.AddRange (ConstructFactionCrimes (content));
                }

                if (factionCrimes.Count () > 0) {
                    factionCrimes = factionCrimes.OrderByDescending (crime => crime.TimeStarted).ToList ();
                    var lastDate = DateTimeOffset.FromUnixTimeSeconds (factionCrimes.First ().TimeStarted);
                    fromCurrent = lastDate.UtcDateTime.AddSeconds(1);
                }
                else {
                    fromCurrent = fromCurrent.AddDays (1) < to ? fromCurrent.AddDays (1) : to;
                }

                toCurrent = fromCurrent.AddDays (1) < to ? fromCurrent.AddDays (1) : to;
            }
            while (fromCurrent < to);

            return factionCrimes;
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
