using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors;

public class PositionAccess (DbSet<Position> set, DbContext context) : EntityAccess<Position> (set, context), IPositionAccess {
    public void AddPosition (Position position) {
        if(!_set.Any(pos => pos.Name == position.Name)) {
            Add (position);
        }
    }

    public Position FindPositionByName (string name) => _set.FirstOrDefault (position => position.Name == name);
}

