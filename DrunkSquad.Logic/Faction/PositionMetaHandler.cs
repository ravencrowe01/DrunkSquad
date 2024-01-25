using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction;
using DrunkSquad.Models.Faction;

namespace DrunkSquad.Logic.Faction {
    public class PositionMetaHandler (IPositionMetaAccess positionMetaAccess) : IPositionMetaHandler {
        public PositionMeta FindByID (int id) => positionMetaAccess.FindByID (id);

        public void AddPositon (PositionMeta position) => positionMetaAccess.Add (position);
    }
}
