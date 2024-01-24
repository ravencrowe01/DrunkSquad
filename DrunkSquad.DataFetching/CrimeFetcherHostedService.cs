using DrunkSquad.Framework.Logic.Faction.Crimes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrunkSquad.DateFetching {
    public class CrimeFetcherHostedService (IServiceProvider services) : IHostedService {
        private IServiceProvider _services = services;

        public async Task StartAsync (CancellationToken cancellationToken) {
            using var scope = _services.CreateScope ();

            var services = scope.ServiceProvider;

            var fetcher = new CrimeFetcher (services.GetRequiredService<ICrimeHandler> (), cancellationToken);

            // One day, I will get someone to look at this and tell me what I'm doing wrong.
            // For now, we shall not await this, as doing so blocks the main thread.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            fetcher.StartAsync ();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public async Task StopAsync (CancellationToken cancellationToken) {
            // CrimeFetcher has the cancellation token peppered through
            await Task.Delay (0, cancellationToken).ConfigureAwait (false); ;
        }
    }
}