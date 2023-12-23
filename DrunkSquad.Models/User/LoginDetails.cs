using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Models.User {
    public class LoginDetails {
        public string ApiKey { get; set; }

        public string Password { get; set; }

        public PasswordVerificationResult Result { get; set; }

        public bool AttemptFailed { get; set; }
    }
}
