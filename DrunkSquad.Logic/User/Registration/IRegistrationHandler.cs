using DrunkSquad.Models.User;

namespace DrunkSquad.Logic.User.Registration {
    public interface IRegistrationHandler {
        Task<RegistrationStatus> RegisterAsync (LoginDetails details);
    }
}