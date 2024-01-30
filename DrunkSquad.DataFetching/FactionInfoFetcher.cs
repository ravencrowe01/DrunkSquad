using DrunkSquad.Framework.Logic.Faction;
using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Logic.Faction;
using DrunkSquad.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.DateFetching {
    internal class FactionInfoFetcher (IFactionInfoHandler factionInfoHandler, IProfileHandler profileHandler, IPositionHandler positionHandler, ICrimeExperienceHandler crimeExperienceHandler, CancellationToken cancellationToken) {
        private IFactionInfoHandler _factionInfoHandler = factionInfoHandler;
        private IProfileHandler _profileHandler = profileHandler;
        private IPositionHandler _positionHandler = positionHandler;
        private ICrimeExperienceHandler _crimeExperienceHandler = crimeExperienceHandler;

        public async Task StartAsync () {
            Console.WriteLine ("Starting faction info fetching.\nSearching database for faction...");

            var factionFound = _factionInfoHandler.GetFactionInfo ();

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            if (factionFound is null) {
                Console.WriteLine ("Faction not found in database, requesting from api...");

                var factionResponse = await _factionInfoHandler.FetchFactionInfoAsync ().ConfigureAwait (false);

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

            Console.WriteLine ("Fetching positions...");
            var positions = await _positionHandler.FetchPositionsAsync ();

            if (positions is not null) {
                foreach (var position in positions.Positions) {
                    _positionHandler.AddPositon (position);
                }
            }
            Console.WriteLine ("Added positions");

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Fetching crime experience...");
            try {
                var crimeExp = await _crimeExperienceHandler.FetchCrimeExperience ();

                if (crimeExp is not null) {
                    foreach (var exp in crimeExp) {
                        _crimeExperienceHandler.AddCrimeExperience (exp);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine (e.Message);
            }
            Console.WriteLine ("Added crime experience.");

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            Console.WriteLine ("Checking for user profiles...");

            var memCount = factionFound.Members.Count ();
            var profCount = _profileHandler.GetAllProfiles ().Count ();

            // Users can be in a weird state of being fetched from the api but not
            // getting added to the db. It theoretically only adds a single loop, but it's having
            // to call the API again, so it is a little slow. That being said, it's for a db
            // seeder, so it doesn't need to be fast, just needs to work.
            // I actually haven't dug into why it does this, but idc.
            while (memCount > profCount) {
                Console.WriteLine ($"Missing { memCount - profCount } profiles, fetching...");

                await FetchProfiles (factionFound).ConfigureAwait (false);

                memCount = factionFound.Members.Count ();
                profCount = _profileHandler.GetAllProfiles ().Count ();
            }
        }

        private async Task FetchProfiles (FactionInfo factionFound) {
            IEnumerable<int> missing = GetMissingIDs (factionFound);

            var profiles = new List<Profile> ();

            foreach (var id in missing) {
                var profileResponse = await _profileHandler.FetchProfileAsync (id).ConfigureAwait (false);

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