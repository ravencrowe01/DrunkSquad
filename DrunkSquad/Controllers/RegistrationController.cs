using DrunkSquad.Logic.User.Registration;
using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class RegistrationController(IRegistrationHandler handler) : Controller {
        public IActionResult Registration () {
            return View (new DSUser ());
        }

        public async Task<IActionResult> Register (DSUser profile) {
            await handler.RegisterAsync (profile);
            return View ("Index");
        }
    }
}