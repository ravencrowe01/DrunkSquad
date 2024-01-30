using TornApi.Net.Models.Faction;

namespace DrunkSquad.Framework.Logic.Faction;

public interface IPositionHandler {
    void AddPositon (Position position);
    Task<PositionsCollection> FetchPositionsAsync ();
    Position FindPositionByID (int id);
}

