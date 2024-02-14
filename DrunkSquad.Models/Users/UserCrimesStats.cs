using Newtonsoft.Json;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Users {
    public class UserCrimesStats {
        [JsonProperty("criminalrecord")]
        public CriminalRecord Crimes { get; set; }

        public int CrimesVersion => Crimes.AutoTheft + Crimes.ComputerCrimes + Crimes.DrugDeals + Crimes.FraudCrimes + Crimes.Murder + Crimes.Other + Crimes.SellingIllegalProducts > 0 ? 1 : 2;
    }
}
