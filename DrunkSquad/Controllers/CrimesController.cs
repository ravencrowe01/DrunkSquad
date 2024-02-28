using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Faction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrunkSquad.Controllers {
    public class CrimesController (ICrimeHandler crimesHandler, IUserHandler userHandler, ICrimeExperienceHandler ceHandler, IMemberHandler memberHandler, IProfileHandler profileHandler) : Controller {
        public async Task<IActionResult> PersonalCrimesOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            await FetchRecentCrimesAsync ();

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var idClaim = principle.Principal.Claims.First (claim => claim.Type == "TornID");

            var tornID = int.Parse (idClaim.Value);

            var user = userHandler.FindUserbyID (tornID);

            var crimeStats = await profileHandler.FetchProfileCrimeStatsAsync (tornID);

            var crimes = crimesHandler.GetAllCrimesForUser (tornID, DateTime.UtcNow.AddMonths (-3), DateTime.UtcNow);

            crimes.CrimeStats = crimeStats;
            crimes.Username = user.Profile.Name;
            crimes.UserID = tornID;

            return View ("PersonalCrimesOverview", crimes);
        }

        public async Task<IActionResult> MembersCrimeOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var roleClaim = principle.Principal.Claims.FirstOrDefault (claim => claim.Type == ClaimTypes.Role);

            if ((int) roleClaim.Value.ToUserRole () >= 1) {
                return RedirectToAction ("Index");
            }

            await FetchRecentCrimesAsync ();

            return View (await BuildFactionCrimesOverviewAsync ());
        }

        private async Task<FactionCrimesOverview> BuildFactionCrimesOverviewAsync () {
            return await Task.Run (() => {
                var crimes = crimesHandler.GetAllCrimes ();
                var ce = ceHandler.GetCrimeExperience ();
                var members = memberHandler.GetAllMembers ();

                var overview = new FactionCrimesOverview {
                    CERanks = ce,
                    Crimes = crimes,
                    Members = members
                };

                return overview;
            });
        }

        public async Task<IActionResult> OrganizedCrimesOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            await FetchRecentCrimesAsync ();

            var crimes = crimesHandler.GetAllCrimes ();

            return View (crimes);
        }

        private async Task FetchRecentCrimesAsync () {
            var from = DateTime.UtcNow.AddDays (-9);

            var crimes = await crimesHandler.FetchCrimesInRangeAsync (from, DateTime.UtcNow);

            crimesHandler.AddFactionCrimes (crimes);
        }
    }
}
