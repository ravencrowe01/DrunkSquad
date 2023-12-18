using DrunkSquad.Models.User;

namespace DrunkSquad.Logic.User {
    public interface IRegistrationHandler {
        Task<RegistrationStatus> RegisterAsync (UserProfile user);
    }
}