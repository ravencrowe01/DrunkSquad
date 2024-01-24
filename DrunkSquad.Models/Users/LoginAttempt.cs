using System.ComponentModel.DataAnnotations;

namespace DrunkSquad.Models.Users {
    public class LoginAttempt {
        [Required (ErrorMessage = "Api Key required")]
        public string ApiKey { get; set; }

        [Required (ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
