using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Logic.Users.Login {
    public interface ILoginHandler {
        PasswordVerificationResult AttemptLogin (LoginDetails logjn);
    }
}
