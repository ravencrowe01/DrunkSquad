using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Faction;

public class StatsOverview {
    public string Member { get; set; }

    public BattleStats BattleStats { get; set; }

    public WorkingStats WorkingStats { get; set; }
}
