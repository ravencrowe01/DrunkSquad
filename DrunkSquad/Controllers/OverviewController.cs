using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class OverviewController : Controller {
        public IActionResult Overview () {
            return View ();
        }
    }
}
