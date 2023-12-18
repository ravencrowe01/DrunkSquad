using DrunkSquad.Database;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DrunkSquad.Logic.User {
    public class LoginHandler (IPasswordHasher<UserProfile> hasher, IUserDBAccess users) : ILoginHandler {
        public async Task<PasswordVerificationResult> AttemptLoginAsync (UserProfile user) {
            var found = users.FindByApiKey (user.ApiKey);

            if (found is not null) {
                var result = hasher.VerifyHashedPassword (user, found.Password, user.Password);

                if (result == PasswordVerificationResult.SuccessRehashNeeded) {
                    found.Password = hasher.HashPassword (user, user.Password);

                    await users.UpdateAsync (found, found.ID);
                }

                return result;
            }

            return PasswordVerificationResult.Failed;
        }


    }
}
