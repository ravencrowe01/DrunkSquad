namespace DrunkSquad.Models.Config {
    public interface IWebsiteConfig {
        IApiConfig Api { get; }
        IFactionConfig Faction { get; }
    }
}
