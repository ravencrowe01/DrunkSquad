using DrunkSquad.Framework.Logic.Faction;
using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Faction;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler crimesHandler, IUserHandler userHandler, IPositionMetaHandler positionMetaHandler) : Controller {
        public IActionResult CrimesOverview () {
            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var tornID = int.Parse (HttpContext.User.Claims.First (claim => claim.Type == "TornID").Value);

            var user = userHandler.FindUserbyID (tornID);

            var positionMeta = positionMetaHandler.FindByID (user.Position.ID);

            if(positionMeta.IsAdmin) {
                return AllCrimesOverview ();
            }
            else {
                return PersonalCrimesOverview ();
            }
        }

        public IActionResult PersonalCrimesOverview () {
            var tornID = int.Parse (HttpContext.User.Claims.First (claim => claim.Type == "TornID").Value);

            var user = userHandler.FindUserbyID (tornID);

            var crimes = crimesHandler.GetAllCrimesForUser (tornID, DateTime.UtcNow.AddMonths (-3), DateTime.UtcNow);

            return View ("PersonalCrimesOverview", crimes);
        }

        public IActionResult AllCrimesOverview () {
            var crimes = crimesHandler.GetAllCrimes ();

            return View ("CrimesOverview", crimes);
        }

        public IActionResult OrganizedCrimesOverview () {
            var crimes = crimesHandler.GetAllCrimes ();

            return View (crimes);
        }

        public IActionResult UserCrimeOverview () {
            return View ();
        }
    }
}
