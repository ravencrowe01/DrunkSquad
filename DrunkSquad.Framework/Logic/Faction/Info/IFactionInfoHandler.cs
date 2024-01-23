using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Framework.Logic.Faction.Info {
    public interface IFactionInfoHandler {
        void AddFactionInfo (FactionInfo info);
        Task<IApiResponse<Basic>> FetchFactionInfoAsync ();
        FactionInfo GetFactionInfo ();
    }
}