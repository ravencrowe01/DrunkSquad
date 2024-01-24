using System.ComponentModel.DataAnnotations;

namespace DrunkSquad.Models.Users {
    public class LoginDetails {
        public int ID { get; set; }

        [Required (ErrorMessage = "Api Key required")]
        public string ApiKey { get; set; }

        [Required (ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}
