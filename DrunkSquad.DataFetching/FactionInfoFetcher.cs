using DrunkSquad.Logic.Extensions;
using DrunkSquad.Logic.Faction.Info;
using DrunkSquad.Logic.Users;
using DrunkSquad.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.DateFetching {
    internal class FactionInfoFetcher (IFactionInfoHandler factionInfoHandler,IProfileHandler profileHandler, CancellationToken cancellationToken) {
        private IFactionInfoHandler _factionInfoHandler = factionInfoHandler;
        private IProfileHandler _profileHandler = profileHandler;

        public async Task StartAsync () {
            Console.WriteLine ("Starting faction info fetching.\nSearching database for faction...");

            var factionFound = _factionInfoHandler.GetFactionInfo ();

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            if (factionFound is null) {
                Console.WriteLine ("Faction not found in database, requesting from api...");

                var factionResponse = await _factionInfoHandler.FetchFactionInfoAsync ();

                var info = factionResponse.Content ?? throw new Exception ("Couldn't fetch faction info.");

                info.ID = 0;

                factionFound = info.ToFactionInfo ();

                Console.WriteLine ("Received faction info from api, adding to database...");

                _factionInfoHandler.AddFactionInfo (factionFound);

                Console.WriteLine ($"Added faction to the database, welcome {factionFound.Name}!");
            }
            else {
                Console.WriteLine ("Database contains faction info.");
            }

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Checking for user profiles...");

            var memCount = factionFound.Members.Count ();
            var profCount = _profileHandler.GetAllProfiles ().Count ();

            while (memCount > profCount) {
                Console.WriteLine ($"Missing { memCount - profCount } profiles, fetching...");

                await FetchProfiles (factionFound);

                memCount = factionFound.Members.Count ();
                profCount = _profileHandler.GetAllProfiles ().Count ();
            }
        }

        private async Task FetchProfiles (FactionInfo factionFound) {
            IEnumerable<int> missing = GetMissingIDs (factionFound);

            var profiles = new List<Profile> ();

            foreach (var id in missing) {
                var profileResponse = await _profileHandler.FetchProfileAsync (id);

                if (profileResponse is not null && profileResponse.Content is not null) {
                    var profile = profileResponse.Content;

                    profiles.Add (profile);
                }
            }

            Console.WriteLine ("Adding profiles to the database...");

            _profileHandler.AddProfiles (profiles);

            Console.WriteLine ("Added profiles to the database");
        }

        private IEnumerable<int> GetMissingIDs (FactionInfo factionFound) {
            var memberIDs = new List<int> ();

            foreach (var member in factionFound.Members) {
                memberIDs.Add (member.MemberID);
            }

            var profileIDs = new List<int> ();

            foreach (var profile in _profileHandler.GetAllProfiles ()) {
                profileIDs.Add (profile.ProfileID);
            }

            var missing = memberIDs.Except (profileIDs);
            return missing;
        }
    }
}