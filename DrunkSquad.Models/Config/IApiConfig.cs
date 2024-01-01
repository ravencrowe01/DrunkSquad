using TornApi.Net.Models.Key;

namespace DrunkSquad.Models.Config {
    public interface IApiConfig {
        string ApiUrl { get; }
        string DefaultConectionString { get; }
        AccessLevel RequiredAccessLevel { get; }

        string GetConnectionString (string name = "Default");
    }
}