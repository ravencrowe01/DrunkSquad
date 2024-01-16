using DrunkSquad.Logic.Faction.Crimes;

namespace DrunkSquad.DateFetching {
    internal class CrimeFetcher (ICrimeHandler crimeHandler, CancellationToken cancellationToken) {
        public async Task StartAsync () {
            var initialDelay = CalculateInitialDelayMilliseconds ();

            var now = DateTime.Now;

            if(cancellationToken.IsCancellationRequested) {
                return;
            }

            await Console.Out.WriteLineAsync("Fetching initial crimes...");

            var crimesTask = crimeHandler.FetchCrimesInRangeAsync (new DateTime(2024, 1, 1), now);

            crimesTask.Wait (cancellationToken);

            var crimes = crimesTask.Result;

            await Console.Out.WriteLineAsync($"Fetched initial crimes, found {crimes.Count()}");

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            await Console.Out.WriteLineAsync("Add initial crimes to database...");

            crimeHandler.AddFactionCrimes (crimes);

            await Console.Out.WriteLineAsync("Added initial crimes to database.");

            await Console.Out.WriteLineAsync($"Delaying for {initialDelay} miliseconds...");

            await Task.Delay (initialDelay, cancellationToken);

            do {
                now = DateTime.Now;

                if (cancellationToken.IsCancellationRequested) {
                    return;
                }

                await Console.Out.WriteLineAsync("Fetching crimes...");

                crimesTask = crimeHandler.FetchCrimesInRangeAsync (now.AddDays (-1), now);

                crimesTask.Wait (cancellationToken);

                crimes = crimesTask.Result;

                await Console.Out.WriteLineAsync ("Fetched crimes, found {crimes.Count()}");

                if (cancellationToken.IsCancellationRequested) {
                    return;
                }

                await Console.Out.WriteLineAsync("Adding crimes to database...");

                crimeHandler.AddFactionCrimes (crimes);

                await Console.Out.WriteLineAsync ("Added crimes to database.");

                await Task.Delay (TimeSpan.FromDays (1), cancellationToken);
            } while (!cancellationToken.IsCancellationRequested);
        }

        private static int CalculateInitialDelayMilliseconds () {
            var now = DateTime.Now;
            var midnight = new DateTime (now.Year, now.Month, now.Day);
            var nextMidnight = midnight.AddDays (1);

            var delay = nextMidnight - now;

            return (int) Math.Ceiling (delay.TotalMilliseconds);
        }
    }
}