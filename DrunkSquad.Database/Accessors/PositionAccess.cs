using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors;

public class PositionAccess (DbSet<Position> set, DbContext context) : EntityAccess<Position> (set, context), IPositionAccess {
}

