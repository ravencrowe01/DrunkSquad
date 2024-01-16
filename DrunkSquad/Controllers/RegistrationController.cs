using DrunkSquad.Logic.Users.Registration;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class RegistrationController (IRegistrationHandler handler) : Controller {
        public IActionResult Registration () {
            return View (new RegistrationAttempt ());
        }

        public async Task<IActionResult> Register (RegistrationAttempt attempt) {
            await handler.RegisterAsync (attempt);
            return View ("../Home/Index");
        }
    }
}