using DrunkSquad.Models.Faction;

namespace DrunkSquad.Logic.Faction.Info {
    public interface IFactionInfoHandler {
        Task FetchFactionInfoAsync (string key);
        FactionInfo GetFactionInfo (int id);
    }
}