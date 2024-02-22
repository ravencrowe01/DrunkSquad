using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class WorkingStatsRegistry (DbSet<WorkingStats> set, DbContext context) : EntityAccess<WorkingStats> (set, context), IWorkingStatsRegistry {

    }
}
