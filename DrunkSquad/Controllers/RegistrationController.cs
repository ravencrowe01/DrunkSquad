using DrunkSquad.Framework.Logic.Users.Registration;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class RegistrationController (IRegistrationHandler handler) : Controller {
        public IActionResult Registration () {
            return View (new RegistrationAttempt ());
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegistrationAttempt attempt) {
            var details = new LoginDetails {
                ApiKey = attempt.ApiKey,
                Password = attempt.Password
            };

            var status = await handler.RegisterAsync (details);

            if(status is not RegistrationStatus.Registered) {
                ModelState.Clear ();

                return View ("Registration", new RegistrationAttempt {
                    PreviousAttempt = status
                });
            }

            return View ("../Home/Index");
        }
    }
}