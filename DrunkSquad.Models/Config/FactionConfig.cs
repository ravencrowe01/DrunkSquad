using DrunkSquad.Models.Common;
using Microsoft.Extensions.Configuration;

namespace DrunkSquad.Models.Config {
    public class FactionConfig (IConfiguration config) : IFactionConfig {
        public int ID => int.Parse (config [$"{Constants.Faction}:{Constants.ID}"]);

        public int Leader => int.Parse (config [$"{Constants.Faction}:{Constants.Leader}"]);

        public int CoLeader => int.Parse (config [$"{Constants.Faction}:{Constants.CoLeader}"]);
    }
}
