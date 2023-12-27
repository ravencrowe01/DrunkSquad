using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController : Controller {
        public IActionResult CrimesOverview () {
            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {
            return View ();
        }
    }
}
