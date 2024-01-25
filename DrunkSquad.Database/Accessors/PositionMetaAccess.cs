using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors;

public class PositionMetaAccess (DbSet<PositionMeta> set, DbContext context) : EntityAccess<PositionMeta> (set, context), IPositionMetaAccess {
}

