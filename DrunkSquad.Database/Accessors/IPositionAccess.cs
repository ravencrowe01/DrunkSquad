using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors;

public interface IPositionAccess : IEntityAccess<Position> {
    void AddPosition (Position position);
    Position FindPositionByName (string name);
}
