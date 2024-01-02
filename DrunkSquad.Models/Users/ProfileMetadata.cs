using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Users;

public class ProfileMetadata {
    public int ProfileMetadataID { get; set; }

    public Profile Owner { get; set; }

    public LoginDetails LoginDetails { get; set; } = new LoginDetails ();

    public UserRole WebsiteRole { get; set; }
}
