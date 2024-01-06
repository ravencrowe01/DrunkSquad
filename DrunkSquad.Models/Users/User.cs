using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Users {
    public class User {
        public int ID { get; set; }

        public int UserID {
            get {
                return Profile is null ? _id : Profile.ProfileID;
            }
            set {
                _id = value;
            }
        }

        private int _id;

        public Profile Profile { get; set; }

        public LoginDetails LoginDetails { get; set; } = new LoginDetails ();

        public UserRole WebsiteRole { get; set; }
    }
}
