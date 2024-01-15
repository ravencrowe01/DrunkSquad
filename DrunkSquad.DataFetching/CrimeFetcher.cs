using DrunkSquad.Logic.Faction.Crimes;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using Raven.Util;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.DateFetching {
    internal class CrimeFetcher (CancellationToken cancellationToken, IWebsiteConfig config, ICrimeHandler crimeHandler) {
        public async Task StartAsync () {
            var initialDelay = CalculateInitialDelayMilliseconds ();

            var now = DateTime.Now;

            var crimes = await FetchCrimesAsync (now.AddDays (-1), now);

            await Task.Delay (initialDelay, cancellationToken);

            do {
                now = DateTime.Now;

                crimes = await FetchCrimesAsync (now.AddDays (-1), now);

                await Task.Delay (TimeSpan.FromDays (1), cancellationToken);
            } while (!cancellationToken.IsCancellationRequested);
        }

        private int CalculateInitialDelayMilliseconds () {
            var now = DateTime.Now;
            var midnight = new DateTime (now.Year, now.Month, now.Day);
            var nextMidnight = midnight.AddDays (1);

            var delay = nextMidnight - now;

            return (int) Math.Ceiling (delay.TotalMilliseconds);
        }

        private async Task<List<FactionCrime>> FetchCrimesAsync (DateTime from, DateTime to) {
            var client = new ApiRequestClient (DefaultApiRequestClientFactory.Instance, config.Api.ApiUrl);

            from = from.ToUniversalTime ();
            to = to.ToUniversalTime ();

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
                IApiResponse<CrimesCollection>? response = await client.GetAsync<CrimesCollection> (requestConfig, TornApi.Net.Models.Key.AccessLevel.LimitedAccess);

                if (response is not null && response.IsValid ()) {
                    var crimes = response.Content;

                    if (crimes is not null) {
                        foreach (var pair in crimes.Crimes) {
                            var id = pair.Key;
                            var crime = pair.Value;
                            crime.CrimeID = int.Parse (id);

                            var factionCrime = Cloner.Clone<Crime, FactionCrime> (crime);

                            if (factionCrime is not null) {
                                fetchedCrimes.Add (factionCrime);
                            }
                        }
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
                        factionCrimes.Add (crime);
                    }
                });
            }
            while (fromCurrent < to);

            return factionCrimes;
        }

    }
}