using System.ComponentModel.DataAnnotations;

namespace DrunkSquad.Models.Users {
    public class RegistrationAttempt {
        [Required (ErrorMessage = "Api Key required")]
        public string ApiKey { get; set; }

        [Required (ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required (ErrorMessage = "Confirmation required")]
        [Compare ("Password", ErrorMessage = "Doesn't match password")]
        public string ConfirmPassword { get; set; }
    }
}
