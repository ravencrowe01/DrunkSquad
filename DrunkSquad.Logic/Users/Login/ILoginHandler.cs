using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DrunkSquad.Logic.Users.Login {
    public interface ILoginHandler {
        PasswordVerificationResult AttemptLogin (LoginDetails logjn);
        IEnumerable<Claim> BuildUserClaims (LoginDetails details);
        void Logout ();
    }
}
