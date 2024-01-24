using DrunkSquad.Framework.Logic.Users.Registration;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class RegistrationController (IRegistrationHandler handler) : Controller {
        public IActionResult Registration () {
            return View (new RegistrationAttempt ());
        }

        public async Task<IActionResult> Register (RegistrationAttempt attempt) {
            var details = new LoginDetails {
                ApiKey = attempt.ApiKey,
                Password = attempt.Password
            };

            await handler.RegisterAsync (details);

            return View ("../Home/Index");
        }
    }
}