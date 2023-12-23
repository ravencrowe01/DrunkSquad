using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.User;

public class DSUser : Profile {
    public string Password { get; set; }

    public string ApiKey { get; set; }

    public Member MembershipInfo { get; set; }
}
