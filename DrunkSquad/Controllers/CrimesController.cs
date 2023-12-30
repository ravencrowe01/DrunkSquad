using DrunkSquad.Logic.Faction.Crimes;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler handler) : Controller {
        //public IActionResult CrimesOverview () {
        public async Task<IActionResult> CrimesOverview () {
            await handler.FetchMostRecentCrimesAsync ("fJ5VhgSCO3nIvYRd");

            //var allCrimes = handler.GetAllCrimes ();

            //var crimes = handler.GetCrimes (DateTime.UtcNow.AddDays (-30), DateTime.UtcNow);

            //var crimesTwo = handler.GetCrimesForUser (3009422, DateTime.UtcNow.AddDays (-30), DateTime.UtcNow);

            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {

            return View (handler.GetAllCrimes());
        }
    }
}
