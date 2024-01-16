using DrunkSquad.Database.Accessors;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DrunkSquad.Logic.Users.Login {
    public class LoginHandler (IPasswordHasher<LoginDetails> hasher, IUserAccess userAccess) : ILoginHandler {
        public PasswordVerificationResult AttemptLogin (LoginDetails login) {
            var found = userAccess.Set.Include (user => user.LoginDetails).Include (user => user.Profile).FirstOrDefault (user => user.LoginDetails.ApiKey == login.ApiKey);

            if (found is not null) {
                var result = hasher.VerifyHashedPassword (login, found.LoginDetails.Password, login.Password);

                if (result == PasswordVerificationResult.SuccessRehashNeeded) {
                    found.LoginDetails.Password = hasher.HashPassword (login, login.Password);

                    userAccess.Update (found);
                }

                return result;
            }

            return PasswordVerificationResult.Failed;
        }

        public IEnumerable<Claim> BuildUserClaims (LoginDetails details) {
            var user = userAccess.FindByApiKey (details.ApiKey);

            return new List<Claim> {
                new Claim(ClaimTypes.Name, user.Profile.Name),
                new Claim(ClaimTypes.Role, Enum.GetName(user.WebsiteRole)),
                new Claim("ApiKey", user.LoginDetails.ApiKey)
            };
        }
    }
}
