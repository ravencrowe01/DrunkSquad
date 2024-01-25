using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Extensions;

public static class BasicExtensions {
    public static FactionInfo ToFactionInfo (this Basic original) => new FactionInfo {
        ID = original.ID,
        Age = original.Age,
        BestChain = original.BestChain,
        Capacity = original.Capacity,
        ColeaderID = original.ColeaderID,
        FactionID = original.FactionID,
        LeaderID = original.LeaderID,
        Members = original.Members,
        Name = original.Name,
        Respect = original.Respect,
        Tag = original.Tag,
        TagImage = original.TagImage
    };
}
