using DrunkSquad.Models.Faction;

namespace DrunkSquad.Framework.Logic.Faction;

public interface IPositionMetaHandler {
    void AddPositon (PositionMeta position);
    PositionMeta FindByID (int id);
}

