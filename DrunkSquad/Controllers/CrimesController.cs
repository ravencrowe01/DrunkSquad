using DrunkSquad.Framework.Logic.Faction.Crimes;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler handler) : Controller {
        //public IActionResult CrimesOverview () {
        public IActionResult CrimesOverview () {
            var key = HttpContext.User.Claims.First (claim => claim.Type == "ApiKey").Value;

            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {
            var crimes = handler.GetAllCrimes ();

            return View (crimes);
        }

        public IActionResult UserCrimeOverview () {
            return View ();
        }
    }
}
