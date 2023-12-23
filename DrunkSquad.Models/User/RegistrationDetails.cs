namespace DrunkSquad.Models.User {
    public class RegistrationDetails {
        public string ApiKey { get; set; }

        public string Password { get; set; }

        public RegistrationStatus Status { get; set; } = RegistrationStatus.Registered;
    }
}
