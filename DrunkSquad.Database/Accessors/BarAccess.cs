using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class BarAccess (DbSet<Bar> set, DbContext context) : EntityAccess<Bar> (set, context), IBarAccess {
    }
}
