using DrunkSquad.Logic.User;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class LoginController (ILoginHandler handler) : Controller {
        [Route ("login")]
        public IActionResult Login () {
            return View (new UserProfile ());
        }

        [HttpPost]
        [Route ("login/attempt")]
        public async Task<IActionResult> Attempt (UserProfile user) {

            if (!ModelState.IsValid) {
                // TODO This needs to be better
                return View ();
            }

            switch (await handler.AttemptLoginAsync (user)) {
                case PasswordVerificationResult.Success:
                    break;
                case PasswordVerificationResult.Failed:
                    break;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    break;
                default:
                    break;
            }

            return View ("Login", user);
        }
    }
}
