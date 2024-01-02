using DrunkSquad.Logic.Faction.Crimes;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler handler) : Controller {
        //public IActionResult CrimesOverview () {
        public IActionResult CrimesOverview () {
            return View ();
        }

        public IActionResult OrganizedCrimesOverview () {

            return View (handler.GetAllCrimes());
        }
    }
}
