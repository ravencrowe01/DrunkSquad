using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using Raven.Util;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Info {
    public class FactionInfoHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionInfoAcces factionInfoAcces) : IFactionInfoHandler {
        // TODO Action result
        public async Task FetchFactionInfoAsync (string key) {
            var response = await apiClient.GetAsync<Basic> (new RequestConfiguration () {
                Key = key,
                ID = config.FactionConfig.ID,
                Section = "faction",
                Selections = ["basic"],
                Comment = "Drunk Squad Faction.Basic Fetch"
            },
            config.ApiConfig.RequiredAccessLevel);

            if (!response.IsValid ()) {
                return;
            }

            var info = Cloner.Clone<Basic, FactionInfo> (response.Content);

            factionInfoAcces.Add (info);
        }

        public FactionInfo GetFactionInfo (int id) => factionInfoAcces.FindByID (id);
    }
}
