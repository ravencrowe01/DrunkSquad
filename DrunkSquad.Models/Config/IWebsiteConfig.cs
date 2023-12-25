using TornApi.Net.Models.Key;

namespace DrunkSquad.Models.Config {
    public interface IWebsiteConfig {
        string GetBaseURL ();
        string GetConnectionString (string name);

        AccessLevel GetRequiredAccessLevel ();

        string [] GetSelectionsForSection (string section);
    }
}
