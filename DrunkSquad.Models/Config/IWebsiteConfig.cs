namespace DrunkSquad.Models.Config {
    public interface IWebsiteConfig {
        IApiConfig ApiConfig { get; }
        IFactionConfig FactionConfig { get; }
    }
}
