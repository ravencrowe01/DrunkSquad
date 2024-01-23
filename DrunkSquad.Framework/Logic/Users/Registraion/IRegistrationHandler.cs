using DrunkSquad.Models.Users;

namespace DrunkSquad.Framework.Logic.Users.Registration {
    public interface IRegistrationHandler {
        Task<RegistrationStatus> RegisterAsync (LoginDetails details);
    }
}