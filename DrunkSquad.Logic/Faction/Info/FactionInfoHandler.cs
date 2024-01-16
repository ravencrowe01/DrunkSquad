using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction.Info {
    public class FactionInfoHandler (IApiRequestClient apiClient, IWebsiteConfig config, IFactionInfoAccess factionInfoAcces) : IFactionInfoHandler {
        public async Task<IApiResponse<Basic>> FetchFactionInfoAsync () {
            var requestConfig = new RequestConfiguration () {
                Key = config.Api.DefaultKey,
                ID = config.Faction.ID,
                Section = "faction",
                Selections = ["basic"],
                Comment = "Drunk Squad Faction.Basic Fetch"
            };

            var response = await apiClient.GetAsync<Basic> (requestConfig, config.Api.RequiredAccessLevel);

            return response;
        }

        public FactionInfo GetFactionInfo () => factionInfoAcces.Set.Include(faction => faction.Members).FirstOrDefault (faction => faction.FactionID == config.Faction.ID);

        public void AddFactionInfo (FactionInfo info) => factionInfoAcces.Add (info);
    }
}
