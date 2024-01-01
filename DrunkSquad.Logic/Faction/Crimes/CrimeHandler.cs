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
    public class CrimeHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionCrimeAccess crimeAccess, IUserAccess userAccess) : ICrimeHandler {
        // TODO Action result
        public async Task FetchMostRecentCrimesAsync (string key) {
            RequestConfiguration reqConfig = new RequestConfiguration {
                Key = key,
                Section = "faction",
                Selections = ["crimes"],
                Comment = "Drunk Squad Crimes Fetch",
                Limit = 10
            };

            var response = await apiClient.GetAsync<CrimesCollection> (reqConfig,
            config.ApiConfig.RequiredAccessLevel);

            if (!response.IsValid ()) {
                return;
            }

            var crimesDictionary = response.Content.Crimes;

            var factionCrimes = await ConstructFactionCrimesAsync (crimesDictionary, key);

            crimeAccess.AddRange (factionCrimes.Crimes);
        }

        private async Task<FactionCrimes> ConstructFactionCrimesAsync (IDictionary<string, Crime> crimes, string key) {
            var factionCrimes = new List<FactionCrime> ();

            foreach (var crimeID in crimes.Keys) {
                var crime = crimes [crimeID];
                var participants = new List<User> ();

                foreach (var participant in crime.Participants) {
                    if(!participants.Any(user => user.ProfileID == participant)) {
                        var user = await ProcessParticipant (key, participant);
                        participants.Add (user);
                    }
                }

                factionCrimes.Add (crime.ToFactionCrime (participants, int.Parse (crimeID)));
            }

            return new FactionCrimes {
                Crimes = factionCrimes
            };
        }

        private async Task<User> ProcessParticipant (string key, int participant) {
            var found = userAccess.FindByID (participant);

            if (found is null) {
                var response = await apiClient.GetAsync<User> (new RequestConfiguration {
                    ID = participant,
                    Key = key,
                    Section = "User",
                    Selections = ["profile"],
                    Comment = "Drunk Squad User Fetch"
                }, config.ApiConfig.RequiredAccessLevel);

                if (response.IsValid ()) {
                    found = response.Content;
                }
            }
            return found;
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
