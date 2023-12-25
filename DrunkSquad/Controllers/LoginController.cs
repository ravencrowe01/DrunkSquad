using DrunkSquad.Logic.User.Login;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class LoginController (ILoginHandler handler) : Controller {
        [Route ("login")]
        public IActionResult Login () {
            return View (new LoginAttempt ());
        }

        [HttpPost]
        [Route ("login/attempt")]
        public IActionResult Attempt (LoginAttempt login) {
            if (!ModelState.IsValid) {
                // TODO This needs to be better
                return View ();
            }

            switch (handler.AttemptLogin (login)) {
                case PasswordVerificationResult.Success:
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return View ("../Home/Index");
                case PasswordVerificationResult.Failed:
                    break;
                default:
                    break;
            }

            return View ("Login", login);
        }
    }
}
