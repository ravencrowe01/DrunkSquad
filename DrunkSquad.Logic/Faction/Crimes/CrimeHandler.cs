using DrunkSquad.Database.Accessors;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public class CrimeHandler (IHttpClientFactory clientFactory, IWebsiteConfig config, IFactionCrimeAccess crimeAccess, IUserAccess userAccess) : ICrimeHandler {
        public async Task FetchMostRecentCrimesAsync (string key) {
            var client = new ApiRequestClient (clientFactory, config.BaseURL);

            var response = await client.GetAsync<CrimesCollection> (new RequestConfiguration {
                Key = key,
                Section = "faction",
                Selections = ["crimes"],
                Comment = "Drunk Squad Crimes Fetch"
            },
            config.RequiredAccessLevel);

            if (!IsResponseValid (response)) {
                return;
            }

            var crimesDictionary = response.Content.Crimes;

            crimeAccess.AddRange (ConstructFactionCrimes (crimesDictionary).Crimes);
        }

        private FactionCrimes ConstructFactionCrimes (IDictionary<string, Crime> crimes) {
            var factionCrimes = new List<FactionCrime> ();

            foreach (var key in crimes.Keys) {
                var crime = crimes [key];
                var participants = new List<User> ();

                foreach (var participant in crime.Participants) {
                    participants.Add (userAccess.FindByID (participant.CrimeParticipantID));
                }

                factionCrimes.Add (crime.ToFactionCrime (participants, int.Parse(key)));
            }

            return new FactionCrimes {
                Crimes = factionCrimes
            };
        }

        private bool IsResponseValid (ApiResponse<CrimesCollection> response) {
            if (!response.KeyStatus.IsKeyUsable
                || (response.HttpResponseMessage is null || !response.HttpResponseMessage.IsSuccessStatusCode)
                || response.Content is null) {
                return false;
            }

            return true;
        }

        public FactionCrimes GetAllCrimes () => new FactionCrimes { Crimes = WithParticipants () };

        public FactionCrimes GetAllCrimes (DateTime from, DateTime to) {
            var found = WithParticipants ().Where (crime => crime.TimeCreated >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeCreated <= GetUnixTimestamp (to.ToUniversalTime ()));

            return new FactionCrimes {
                Crimes = found
            };
        }

        public FactionCrimes GetAllCrimesForUser (int id, DateTime from, DateTime to) {
            var found = WithParticipants ().Where (crime => crime.TimeCreated >= GetUnixTimestamp (from.ToUniversalTime ()) && crime.TimeCreated <= GetUnixTimestamp (to.ToUniversalTime ()) && crime.Participants.Any (participant => participant.ProfileID == id));

            return new FactionCrimes {
                Crimes = found
            };
        }

        private IIncludableQueryable<FactionCrime, IEnumerable<User>> WithParticipants () {
            return crimeAccess.Set.Include (crime => crime.Participants);
        }



        private static long GetUnixTimestamp (DateTime dateTime) {
            DateTime unixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeDifference = dateTime.ToUniversalTime () - unixEpoch;

            return (long) timeDifference.TotalSeconds;
        }
    }
}
