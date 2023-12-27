using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public class CrimeHandler (IHttpClientFactory clientFactory, IWebsiteConfig config, IFactionCrimeAccess crimeAccess) : ICrimeHandler {
        public async Task FetchMostRecentCrimesAsync (string key) {
            var client = new ApiRequestClient (clientFactory, config.BaseURL);

            var response = await client.GetAsync<FactionCrimes> (new RequestConfiguration {
                Key = key,
                Section = "faction",
                Selections = ["crimes"],
                Comment = "Drunk Squad Crimes Fetch"
            },
            config.RequiredAccessLevel);

            if(!IsResponseValid (response)) {
                return;
            }

            var crimesDictionary = response.Content.Crimes;

            var crimes = new List<Crime> ();

            foreach(var id in crimesDictionary.Keys) {
                var crime = crimesDictionary [id];
                crime.ID = int.Parse(id);
                crimes.Add (crime);
            }

            crimeAccess.AddRange (crimes);
        }

        private bool IsResponseValid (ApiResponse<FactionCrimes> response) {
            if (!response.KeyStatus.IsKeyUsable
                || (response.HttpResponseMessage is null || !response.HttpResponseMessage.IsSuccessStatusCode)
                || response.Content is null) {
                return false;
            }

            return true;
        }

        public IEnumerable<Crime> GetCrimes (DateTime from, DateTime to) {
            var fromEpoch = GetUnixTimestamp (from);
            var toEpoch = GetUnixTimestamp (to);

            var found = crimeAccess.Set.Where (crime => crime.TimeCreated >= GetUnixTimestamp (from)
            && crime.TimeCreated <= GetUnixTimestamp (to));

            return found.ToList ();
        }

        public IEnumerable<Crime> GetCrimesForUser (int id, DateTime from, DateTime to) {
            var found = crimeAccess.Set.Where (crime => crime.TimeCreated >= GetUnixTimestamp (from)
            && crime.TimeCreated <= GetUnixTimestamp (to)
            && crime.Participants.Where(p => p.ID == id).Any());

            return found.ToList ();
        }

        private static long GetUnixTimestamp (DateTime dateTime) {
            DateTime unixEpoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeDifference = dateTime.ToUniversalTime () - unixEpoch;

            return (long) timeDifference.TotalSeconds;
        }

        public IEnumerable<Crime> GetAllCrimes () => ((DbSet<Crime>) crimeAccess.Set).Include(crime => crime.Participants).ToList();
    }
}
