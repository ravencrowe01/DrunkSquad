using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Faction;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Faction {
    public class PositionHandler (IPositionAccess positionAccess) : IPositionHandler {
        public Position FindPositionByID (int id) => positionAccess.FindByID (id);

        public void AddPositon (Position position) => positionAccess.Add (position);
    }
}
