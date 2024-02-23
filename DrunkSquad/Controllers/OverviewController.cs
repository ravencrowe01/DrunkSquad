using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrunkSquad.Controllers {
    public class OverviewController (IFactionInfoHandler factionInfo, IUserHandler userHandler, IMemberHandler memberHandler) : Controller {
        private IUserHandler _userHandler = userHandler;
        private IMemberHandler _memberHandler = memberHandler;

        public async Task<IActionResult> Overview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var roleClaim = principle.Principal.Claims.FirstOrDefault (claim => claim.Type == ClaimTypes.Role);

            if (roleClaim.Value.ToUserRole () != UserRole.Admin) {
                return RedirectToAction ("Index");
            }

            var info = factionInfo.GetFactionInfo ();

            return View (info);
        }

        public async Task<IActionResult> StatsOverview () {
            var authResult = await HttpContext.AuthenticateAsync ();

            if (!authResult.Succeeded) {
                return RedirectToAction ("Login", "Login");
            }

            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var principle = await HttpContext.AuthenticateAsync ();

            var roleClaim = principle.Principal.Claims.FirstOrDefault (claim => claim.Type == ClaimTypes.Role);

            if (roleClaim.Value.ToUserRole () != UserRole.Admin) {
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
                }else {
                    overview.Stats.Add (new StatsOverview {
                        Member = member.Name
                    });
                }
            }

            return View (overview);
        }
    }
}
