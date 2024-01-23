using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Faction.Info;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrunkSquad.DateFetching {
    public class FactionInfoFetcherHostedService (IServiceProvider services) : IHostedService {
        private IServiceProvider _services = services;

        public async Task StartAsync (CancellationToken cancellationToken) {
            using var scope = _services.CreateScope ();

            var services = scope.ServiceProvider;

            var factionInfoFetcher = new FactionInfoFetcher (services.GetRequiredService<IFactionInfoHandler>(), services.GetRequiredService<IProfileHandler> (), cancellationToken);

            await factionInfoFetcher.StartAsync ().ConfigureAwait (false);
        }

        public async Task StopAsync (CancellationToken cancellationToken) {
            // Same deal as the other fetcher service
            await Task.Delay (0, cancellationToken).ConfigureAwait (false);
        }
    }
}