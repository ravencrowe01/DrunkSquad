namespace DrunkSquad.Models.User {
    public class RegistrationAttempt : LoginDetails {
        public RegistrationStatus Status { get; set; } = RegistrationStatus.Registered;
    }
}
