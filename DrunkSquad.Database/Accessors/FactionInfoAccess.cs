using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class FactionInfoAccess (DbSet<FactionInfo> set, DbContext context) : EntityAccess<FactionInfo> (set, context), IFactionInfoAccess {
    }
}
