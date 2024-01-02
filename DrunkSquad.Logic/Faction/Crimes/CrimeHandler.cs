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
    public class CrimeHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionCrimeAccess crimeAccess, ICrimeParticipantAccess crimeParticipantAccess, IMemberAccess memberAccess) : ICrimeHandler {
        // TODO Action result
        public async Task FetchMostRecentCrimesAsync (string key) {
            RequestConfiguration reqConfig = new RequestConfiguration {
                Key = key,
                Section = "faction",
                Selections = ["crimes"],
                Comment = "Drunk Squad Crimes Fetch",
            };

            var response = await apiClient.GetAsync<CrimesCollection> (reqConfig,
            config.ApiConfig.RequiredAccessLevel);

            if (!response.IsValid ()) {
                return;
            }

            var crimesDictionary = response.Content.Crimes;

            var factionCrimes = ConstructFactionCrimes (crimesDictionary);

            var crimes = factionCrimes.Crimes;

            foreach (var crime in crimes) {
                if (!crimeAccess.Set.Any (c => c.CrimeID == crime.CrimeID)) {
                    crimeAccess.Add (crime);

                    crimeParticipantAccess.AddRange (crime.CrimeParticipants);
                }
            }
        }

        private FactionCrimes ConstructFactionCrimes (IDictionary<string, Crime> crimes) {
            var factionCrimes = new List<FactionCrime> ();

            foreach (var crimeID in crimes.Keys) {
                var crime = crimes [crimeID];

                var factionCrime = Cloner.Clone<Crime, FactionCrime> (crime);

                factionCrime.CrimeID = int.Parse (crimeID);

                factionCrime.SetParticipants (memberAccess);

                factionCrimes.Add (factionCrime);
            }

            return new FactionCrimes {
                Crimes = factionCrimes
            };
        }

        public FactionCrimes GetAllCrimes () => new FactionCrimes { Crimes = WithParticipants () };

        public FactionCrimes GetAllCrimes (DateTime from, DateTime to) {
            var found = WithParticipants ().Where (crime => crime.TimeStarted >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeStarted <= GetUnixTimestamp (to.ToUniversalTime ()));

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

        private IIncludableQueryable<FactionCrime, IEnumerable<CrimeParticipant>> WithParticipants () {
            return crimeAccess.Set.Include (crime => crime.CrimeParticipants);
        }

        private static long GetUnixTimestamp (DateTime dateTime) {
            DateTime unixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeDifference = dateTime.ToUniversalTime () - unixEpoch;

            return (long) timeDifference.TotalSeconds;
        }
    }
}
