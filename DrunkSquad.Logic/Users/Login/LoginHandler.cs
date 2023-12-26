using DrunkSquad.Database;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DrunkSquad.Logic.Users.Login {
    public class LoginHandler (IPasswordHasher<LoginDetails> hasher, DrunkSquadDBContext db) : ILoginHandler {
        public PasswordVerificationResult AttemptLogin (LoginDetails login) {
            var found = db.UserAccess.FindByApiKey (login.ApiKey);

            if (found is not null) {
                var result = hasher.VerifyHashedPassword (login, found.LoginDetails.Password, login.Password);

                if (result == PasswordVerificationResult.SuccessRehashNeeded) {
                    found.LoginDetails.Password = hasher.HashPassword (login, login.Password);

                    db.UserAccess.Update (found);
                }

                return result;
            }

            return PasswordVerificationResult.Failed;
        }

        public void Logout () {

        }

        public IEnumerable<Claim> BuildUserClaims(LoginDetails details) {
            var user = db.UserAccess.FindByApiKey (details.ApiKey);

            return new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, Enum.GetName(user.WebsiteRole)),
                new Claim("ApiKey", user.LoginDetails.ApiKey)
            };
        }
    }
}
