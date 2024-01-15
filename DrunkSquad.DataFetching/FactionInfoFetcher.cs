#nullable disable
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Logic.Faction.Info;
using DrunkSquad.Logic.Users;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;

namespace DrunkSquad.DateFetching {
    internal class FactionInfoFetcher (CancellationToken cancellationToken, IFactionInfoHandler factionInfoHandler, IUserHandler userHandler) {
        public async Task StartAsync () {
            var factionFound = factionInfoHandler.GetFactionInfo ();

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            var factionResponse = await factionInfoHandler.FetchFactionInfoAsync () ?? throw new Exception ("Couldn't fetch faction info.");

            if (factionFound is null) {
                var info = factionResponse.Content;
                info.ID = 0;

                factionFound = info.ToFactionInfo ();

                factionInfoHandler.AddFactionInfo (factionFound);
            }

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            if (factionFound.Members.Count () != userHandler.GetAllUsers ().Count ()) {
                var users = new List<User> ();

                foreach (var member in factionFound.Members) {
                    var userResponse = await userHandler.FetchUserAsync (member.MemberID);

                    if (userResponse is not null) {
                        users.Add (userResponse.Content);
                    }
                }

                userHandler.AddUsers (users);
            }
        }
    }
}