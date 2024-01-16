using DrunkSquad.Logic.Faction.Crimes;

namespace DrunkSquad.DateFetching {
    internal class CrimeFetcher (ICrimeHandler crimeHandler, CancellationToken cancellationToken) {
        public async Task StartAsync () {
            var initialDelay = CalculateInitialDelayMilliseconds ();

            var now = DateTime.Now;

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Fetching initial crimes...");

            var crimesTask = crimeHandler.FetchCrimesInRangeAsync (new DateTime (2024, 1, 1), now);

            crimesTask.Wait (cancellationToken);

            var crimes = crimesTask.Result;

            Console.WriteLine ($"Fetched initial crimes, found {crimes.Count ()}");

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Adding initial crimes to database...");

            crimeHandler.AddFactionCrimes (crimes);

            Console.WriteLine ("Added initial crimes to database.");

            Console.WriteLine ($"Delaying for {initialDelay} miliseconds...");

            await Task.Delay (initialDelay, cancellationToken);

            do {
                now = DateTime.Now;

                if (cancellationToken.IsCancellationRequested) {
                    return;
                }

                Console.WriteLine ("Fetching crimes...");

                crimesTask = crimeHandler.FetchCrimesInRangeAsync (now.AddDays (-1), now);

                crimesTask.Wait (cancellationToken);

                crimes = crimesTask.Result;

                Console.WriteLine ("Fetched crimes, found {crimes.Count()}");

                if (cancellationToken.IsCancellationRequested) {
                    return;
                }

                Console.WriteLine ("Adding crimes to database...");

                crimeHandler.AddFactionCrimes (crimes);

                Console.WriteLine ("Added crimes to database.");

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