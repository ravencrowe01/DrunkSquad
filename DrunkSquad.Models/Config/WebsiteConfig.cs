using Microsoft.Extensions.Configuration;

namespace DrunkSquad.Models.Config {
    public class WebsiteConfig (IConfiguration config) : IWebsiteConfig {
        public IApiConfig Api { get; } = new ApiConfig (config);

        public IFactionConfig Faction { get; } = new FactionConfig (config);
    }
}
