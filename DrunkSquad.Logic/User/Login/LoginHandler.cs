using DrunkSquad.Database;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Logic.User.Login {
    public class LoginHandler (IPasswordHasher<LoginDetails> hasher, IUserAccess users) : ILoginHandler {
        public PasswordVerificationResult AttemptLogin (LoginDetails login) {
            var found = users.FindByApiKey (login.ApiKey);

            if (found is not null) {
                var result = hasher.VerifyHashedPassword (login, found.LoginDetails.Password, login.Password);

                if (result == PasswordVerificationResult.SuccessRehashNeeded) {
                    found.LoginDetails.Password = hasher.HashPassword (login, login.Password);

                    users.Update (found);
                }

                return result;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}
