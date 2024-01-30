using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Crimes {
    public class CrimeExperienceHandler (IApiRequestClient apiClient, IWebsiteConfig config, ICrimeExperienceEntryAccess crimeExperienceAccess, IMemberAccess memberAccess) : ICrimeExperienceHandler {
        public async Task<IEnumerable<CrimeExperienceEntry>> FetchCrimeExperience () {
            var requestConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                Section = "faction",
                Selections = ["crimeexp"],
                Comment = "DrunkSquad Crime Exp Fetching"
            };

            var response = await apiClient.GetAsync<CrimeExperience> (requestConfig, config.Api.RequiredAccessLevel);

            var entries = new List<CrimeExperienceEntry> ();

            if (response is not null && response.IsValid ()) {

                var members = response.Content.Members.ToList ();

                for (int i = 0; i < members.Count (); i++) {
                    var member = memberAccess.FindMemberByProfileID (members [i]);
                    var rank = i + 1;

                    entries.Add (new CrimeExperienceEntry {
                        Member = member,
                        Rank = rank
                    });
                }
            }

            return entries;
        }

        public IEnumerable<CrimeExperienceEntry> GetCrimeExperience () => crimeExperienceAccess.Set.ToList ().OrderBy (ce => ce.Rank);

        public void AddCrimeExperience (CrimeExperienceEntry entry) => crimeExperienceAccess.AddCE (entry);
    }
}
