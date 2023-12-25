using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.User;

public class User : Profile {
    public LoginDetails LoginDetails { get; set; } = new LoginDetails ();

    public Member MembershipInfo { get; set; }
}
