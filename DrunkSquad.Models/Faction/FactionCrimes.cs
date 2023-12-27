using Newtonsoft.Json;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Models.Faction {
    public class FactionCrimes {
        [JsonProperty ("crimes")]
        public IDictionary<string, Crime> Crimes { get; set; }
    }
}
