using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public class FactionCrimeAccess (DbSet<FactionCrime> set, DbContext context) : EntityAccess<FactionCrime> (set, context), IFactionCrimeAccess {
    }
}
