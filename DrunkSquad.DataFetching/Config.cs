using DrunkSquad.Models.Config;

#nullable disable
namespace DrunkSquad.DateFetching {
    internal class Config : IWebsiteConfig {
        public IApiConfig Api { get; set; }

        public IFactionConfig Faction { get; set; }
    }
}