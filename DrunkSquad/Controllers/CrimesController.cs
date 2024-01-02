using DrunkSquad.Logic.Faction.Crimes;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler handler) : Controller {
        //public IActionResult CrimesOverview () {
        public async Task<IActionResult> CrimesOverview () {
            var key = HttpContext.User.Claims.First (claim => claim.Type == "ApiKey").Value;

            await handler.FetchMostRecentCrimesAsync (key);
            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {

            return View (handler.GetAllCrimes());
        }
    }
}
