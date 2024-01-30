using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction;
using DrunkSquad.Models.Config;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Faction {
    public class PositionHandler (IApiRequestClient apiClient, IWebsiteConfig config, IPositionAccess positionAccess) : IPositionHandler {
        public async Task<PositionsCollection> FetchPositionsAsync () {
            var requestConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                Section = "faction",
                Selections = ["positions"],
                Comment = "DrunkSquad Positions Fetch"
            };

            var response = await apiClient.GetAsync<PositionsCollection> (requestConfig, config.Api.RequiredAccessLevel);

            if(response != null && response.IsValid ()) {
                return response.Content;
            }

            return default;
        }

        public Position FindPositionByID (int id) => positionAccess.FindByID (id);

        public void AddPositon (Position position) => positionAccess.AddPosition (position);
    }
}
