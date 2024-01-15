//using DrunkSquad.Logic.Faction.Crimes;
//using DrunkSquad.Models.Config;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace DrunkSquad.Logic.DataSync {
//    public class CrimeFetcherBackgroundService (IServiceScopeFactory serviceScopeFactory) : BackgroundService {
//        protected override async Task ExecuteAsync (CancellationToken stoppingToken) {
//            using var scope = serviceScopeFactory.CreateScope ();

//            var scopedServices = scope.ServiceProvider;

//            var config = scopedServices.GetRequiredService<IWebsiteConfig> ();
//            var crimeHandler = scopedServices.GetRequiredService<ICrimeHandler> ();

//            await FetchCrimesAsync (config, crimeHandler, stoppingToken);

//            //var now = DateTime.Now;
//            //var midnight = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
//            //var targetTime = midnight.AddDays (1);

//            //var fetchTimer = new System.Timers.Timer (targetTime - DateTime.Now);

//            //fetchTimer.Elapsed += async (sender, args) => {
//            //    await FetchCrimesAsync (config, crimeHandler, stoppingToken);
//            //};

//            //fetchTimer.Start ();
//        }

//        private static async Task FetchCrimesAsync (IWebsiteConfig config, ICrimeHandler crimeHandler, CancellationToken stoppingToken) {
//            if (stoppingToken.IsCancellationRequested) {
//                return;
//            }

//            var crimes = await crimeHandler.GetCrimesInRangeAsync (config.ApiConfig.DefaultKey, DateTime.UtcNow.AddDays (-7), DateTime.UtcNow);

//            crimeHandler.AddFactionCrimes (crimes);
//        }
//    }
//}
