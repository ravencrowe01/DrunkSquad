using DrunkSquad.Models.Common;
using Microsoft.Extensions.Configuration;
using TornApi.Net.Models.Common.Extensions;
using TornApi.Net.Models.Key;

namespace DrunkSquad.Models.Config {
    public class ApiConfig (IConfiguration config) : IApiConfig {
        public string DefaultKey => config [$"{Constants.Api}:{Constants.DefaultKey}"];

        public string ApiUrl => config [$"{Constants.Api}:{Constants.ApiUrl}"];

        public string DefaultConectionString => config [$"{Constants.ConnectionStrings}:{Constants.Default}"];

        public AccessLevel RequiredAccessLevel {
            get {
                var level = config [$"{Constants.Api}:{Constants.RequiredApiLevel}"].ToAccessLevel ();
                return level;
            }
        }

        public string GetConnectionString (string name = "Default") => config.GetConnectionString (name);
    }
}
