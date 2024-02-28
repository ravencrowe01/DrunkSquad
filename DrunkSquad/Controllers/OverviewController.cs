using DrunkSquad.Framework.Logic.Faction.Crimes;
using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Logic.Users;
using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrunkSquad.Controllers {
    public class OverviewController (IFactionInfoHandler factionInfo, IUserHandler userHandler, IMemberHandler memberHandler, IProfileHandler profileHandler, ICrimeHandler crimeHandler) : Controller {
        private IUserHandler _userHandler = userHandler;
        private IMemberHandler _memberHandler = memberHandler;
        private IProfileHandler _profileHandler = profileHandler;
        private ICrimeHandler _crimeHandler = crimeHandler;

        public async Task<IActionResult> Overview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var roleClaim = principle.Principal.Claims.FirstOrDefault (claim => claim.Type == ClaimTypes.Role);

            if ((int) roleClaim.Value.ToUserRole () < 1) {
                return RedirectToAction ("Index");
            }

            var info = factionInfo.GetFactionInfo ();

            return View (info);
        }

        public async Task<IActionResult> PersonalStatsOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var tornID = int.Parse (principle.Principal.Claims.FirstOrDefault (claim => claim.Type == "TornID").Value);

            var user = _userHandler.FindUserbyID (tornID);

            var stats = new StatsOverview {
                BattleStats = user.BattleStats,
                WorkingStats = user.WorkingStats
            };

            var crimeStats = await _profileHandler.FetchProfileCrimeStatsAsync (tornID);

            var crimes = _crimeHandler.GetAllCrimesForUser (tornID, DateTime.UtcNow.AddMonths (-3), DateTime.UtcNow);

            crimes.CrimeStats = crimeStats;
            crimes.Username = user.Profile.Name;
            crimes.UserID = tornID;

            var overview = new UserOverview {
                Crimes = crimes,
                Stats = stats
            };

            return View (overview);
        }

        public async Task<IActionResult> StatsOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var roleClaim = principle.Principal.Claims.FirstOrDefault (claim => claim.Type == ClaimTypes.Role);

            if ((int) roleClaim.Value.ToUserRole () < 1) {
                return RedirectToAction ("Index");
            }

            var overview = new FactionStatsOverview ();

            var members = _memberHandler.GetAllMembers ();

            var users = _userHandler.GetAllUsers ();

            foreach(var member in members) {
                var user = users.FirstOrDefault (user => user.Profile.ProfileID == member.MemberID);

                if(user is not null) {
                    overview.Stats.Add (new StatsOverview {
                        Member = member.Name,
                        BattleStats = user.BattleStats,
                        WorkingStats = user.WorkingStats
                    });
                } else {
                    overview.Stats.Add (new StatsOverview {
                        Member = member.Name
                    });
                }
            }

            return View (overview);
        }
    }
}
