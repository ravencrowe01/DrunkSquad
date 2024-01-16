using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Users {
    public class User {
        public int ID { get; set; }

        public Profile Profile { get; set; }

        public LoginDetails LoginDetails { get; set; } = new LoginDetails ();

        public UserRole WebsiteRole { get; set; }
    }
}
