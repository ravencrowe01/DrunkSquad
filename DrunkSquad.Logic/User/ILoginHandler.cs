using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Logic.User {
    public interface ILoginHandler {
        Task<PasswordVerificationResult> AttemptLoginAsync (UserProfile user);
    }
}
