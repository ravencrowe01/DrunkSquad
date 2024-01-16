using DrunkSquad.Logic.Extensions;
using DrunkSquad.Logic.Faction.Info;
using DrunkSquad.Logic.Users;
using DrunkSquad.Models.Users;

namespace DrunkSquad.DateFetching {
    internal class FactionInfoFetcher (IFactionInfoHandler factionInfoHandler, IUserHandler userHandler, IProfileHandler profileHandler, CancellationToken cancellationToken) {
        public async Task StartAsync () {
            Console.WriteLine ("Starting faction info fetching.\nSearching database for faction...");

            var factionFound = factionInfoHandler.GetFactionInfo ();

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            if (factionFound is null) {
                Console.WriteLine ("Faction not found in database, requesting from api...");

                var factionResponse = await factionInfoHandler.FetchFactionInfoAsync ();

                var info = factionResponse.Content ?? throw new Exception ("Couldn't fetch faction info.");

                info.ID = 0;

                factionFound = info.ToFactionInfo ();

                Console.WriteLine ("Received faction info from api, adding to database...");

                factionInfoHandler.AddFactionInfo (factionFound);

                Console.WriteLine ($"Added faction to the database, welcome {factionFound.Name}!");
            }
            else {
                Console.WriteLine ("Database contains faction info.");
            }

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Checking for user profiles...");

            if (factionFound.Members.Count () > userHandler.GetAllUsers ().Count ()) {
                Console.WriteLine ("Missing profiles, fetching...");

                var users = new List<User> ();

                foreach (var member in factionFound.Members) {
                    var profileResponse = await profileHandler.FetchProfileAsync (member.MemberID);

                    if (profileResponse is not null && profileResponse.Content is not null) {
                        var profile = profileResponse.Content;

                        var user = new User {
                            Profile = profile
                        };

                        users.Add (user);
                    }
                }

                Console.WriteLine ("Adding user profiles to the database...");

                userHandler.AddUsers (users);

                Console.WriteLine ("Added user profiles to the database");
            }
        }
    }
}