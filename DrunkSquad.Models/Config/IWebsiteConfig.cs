using TornApi.Net.Models.Key;

namespace DrunkSquad.Models.Config {
    public interface IWebsiteConfig {
        string BaseURL { get; }

        string GetConnectionString (string name);

        AccessLevel RequiredAccessLevel { get; }

        string [] GetSelectionsForSection (string section);
    }
}
