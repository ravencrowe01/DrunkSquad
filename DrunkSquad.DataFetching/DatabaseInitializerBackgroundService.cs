//using DrunkSquad.Logic.Extensions;
//using DrunkSquad.Logic.Faction.Info;
//using DrunkSquad.Logic.Users;
//using DrunkSquad.Models.Config;
//using DrunkSquad.Models.Faction;
//using DrunkSquad.Models.Users;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace DrunkSquad.Logic.DataSync {
//    public class DatabaseInitializerBackgroundService (IServiceScopeFactory serviceScopeFactory) : BackgroundService {
//        protected override async Task ExecuteAsync (CancellationToken stoppingToken) {
//            using var scope = serviceScopeFactory.CreateScope ();

//            var scopedServices = scope.ServiceProvider;

//            var config = scopedServices.GetRequiredService<IWebsiteConfig> ();
//            var factionInfoHandler = scopedServices.GetRequiredService<IFactionInfoHandler> ();
//            var userHandler = scopedServices.GetRequiredService<IUserHandler> ();

//            var factionFound = factionInfoHandler.GetFactionInfoByFactionID (config.FactionConfig.ID);

//            if (stoppingToken.IsCancellationRequested) {
//                return;
//            }

//            var factionResponse = await factionInfoHandler.FetchFactionInfoAsync (config.ApiConfig.DefaultKey);

//            if (factionResponse is null) {
//                // TODO Need better logging here
//                throw new Exception ("Couldn't fetch faction info.");
//            }

//            if (factionFound is null) {
//                var info = factionResponse.Content;
//                info.ID = 0;

//                factionFound = info.ToFactionCrime ();

//                if (factionInfoHandler.GetFactionInfo (factionFound.FactionID) is null) {
//                    factionInfoHandler.AddFactionInfo (factionFound);
//                }
//            }

//            if (factionFound.Members.Count () != userHandler.GetAllUsers ().Count ()) {
//                var users = new List<User> ();

//                foreach (var member in factionFound.Members) {
//                    var userResponse = await userHandler.FetchUserAsync (config.ApiConfig.DefaultKey, member.MemberID);

//                    if (userResponse is not null) {
//                        users.Add (userResponse.Content);
//                    }
//                }

//                userHandler.AddUsers (users);
//            }
//        }
//    }
//}
