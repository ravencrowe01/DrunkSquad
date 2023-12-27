using Microsoft.AspNetCore.Mvc;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Controllers {
    public class CrimesController : Controller {
        public IActionResult CrimesOverview () {
            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {
            var crime = new Crime ();
            return View ();
        }
    }
}
