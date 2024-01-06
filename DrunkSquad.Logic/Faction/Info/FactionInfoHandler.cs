using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Info {
    public class FactionInfoHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionInfoAccess factionInfoAcces) : IFactionInfoHandler {
        // TODO Action result
        public async Task<IApiResponse<Basic>> FetchFactionInfoAsync (string key) {
            var requestConfig = new RequestConfiguration () {
                Key = key,
                ID = config.FactionConfig.ID,
                Section = "faction",
                Selections = ["basic"],
                Comment = "Drunk Squad Faction.Basic Fetch"
            };

            var response = await apiClient.GetAsync<Basic> (requestConfig, config.ApiConfig.RequiredAccessLevel);

            if (response.IsValid ()) {
                return response;
            }

            return null;
        }

        public FactionInfo GetFactionInfo (int id) => factionInfoAcces.FindByID (id);

        public void AddFactionInfo (FactionInfo info) => factionInfoAcces.Add (info);
    }
}
