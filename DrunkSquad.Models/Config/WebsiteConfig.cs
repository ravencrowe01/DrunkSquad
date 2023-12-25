using Microsoft.Extensions.Configuration;
using TornApi.Net.Models.Common.Extensions;
using TornApi.Net.Models.Key;

namespace DrunkSquad.Models.Config {
    public class WebsiteConfig (IConfiguration config) : IWebsiteConfig {
        public string GetBaseURL () => config ["Api:BaseApiUrl"];

        public string GetConnectionString (string name) => config.GetConnectionString (name);

        public AccessLevel GetRequiredAccessLevel () {
            var level = config ["Api:RequiredApiLevel"].ToAccessLevel();
            return level;
        }

        public string [] GetSelectionsForSection (string section) => config.GetSection ($"Api:Sections:{section}").Get<string []> ();
    }
}
