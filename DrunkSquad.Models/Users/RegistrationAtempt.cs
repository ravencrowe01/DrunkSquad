namespace DrunkSquad.Models.Users {
    public class RegistrationAttempt : LoginDetails {
        public RegistrationStatus Status { get; set; } = RegistrationStatus.Registered;
    }
}
