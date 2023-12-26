using DrunkSquad.Models.Users;

namespace DrunkSquad.Logic.Users.Registration {
    public interface IRegistrationHandler {
        Task<RegistrationStatus> RegisterAsync (LoginDetails details);
    }
}