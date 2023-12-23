using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Logic.User.Login {
    public interface ILoginHandler {
        PasswordVerificationResult AttemptLogin (LoginDetails logjn);
    }
}
