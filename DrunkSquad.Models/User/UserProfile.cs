using TornApi.Net.Models.User;

namespace DrunkSquad.Models.User;

public class UserProfile : Profile {
    public string Password { get; set; }

    public string ApiKey { get; set; }

    public bool LoggedIn { get; set; } = false;
}
