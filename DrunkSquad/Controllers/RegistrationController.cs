using DrunkSquad.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class RegistrationController : Controller {
        public IActionResult Registration () {
            return View (new UserProfile());
        }

        public IActionResult Register () {
            return View ("Index");
        }
    }
}