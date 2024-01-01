using Microsoft.Extensions.Configuration;

namespace DrunkSquad.Models.Config {
    public class WebsiteConfig (IConfiguration config) : IWebsiteConfig {
        public IApiConfig ApiConfig { get; } = new ApiConfig (config);

        public IFactionConfig FactionConfig { get; } = new FactionConfig (config);
    }
}
