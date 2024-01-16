using DrunkSquad.Logic.Users.Login;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrunkSquad.Controllers {
    public class LoginController (ILoginHandler handler) : Controller {
        [Route ("login")]
        public IActionResult Login () {
            return View (new LoginAttempt ());
        }

        [HttpPost]
        [Route ("login/attempt")]
        public async Task<IActionResult> Attempt (LoginAttempt login) {
            if (!ModelState.IsValid) {
                // TODO This needs to be better
                return View ();
            }

            switch (handler.AttemptLogin (login)) {
                case PasswordVerificationResult.Success:
                case PasswordVerificationResult.SuccessRehashNeeded:
                    var claims = handler.BuildUserClaims (login);

                    var claimsIdentity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties {
                        ExpiresUtc = new DateTimeOffset (DateTime.UtcNow.AddMinutes (1440)),
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal (claimsIdentity), authProperties);

                    return RedirectToAction ("Index", "Home");
                case PasswordVerificationResult.Failed:
                    break;
                default:
                    break;
            }

            return View ("Login", login);
        }

        public async Task<IActionResult> Logout () {
            await HttpContext.SignOutAsync (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction ("Index", "Home");
        }
    }
}
