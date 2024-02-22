using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class BattleStatsRegistry (DbSet<BattleStats> set, DbContext context) : EntityAccess<BattleStats> (set, context), IBattleStatsRegistry {
    }
}
