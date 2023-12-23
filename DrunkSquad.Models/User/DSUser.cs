using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.User;

public class DSUser : Profile {
    public LoginDetails LoginDetails { get; set; }

    public Member MembershipInfo { get; set; }
}
