using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Faction;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class OverviewController (IFactionInfoHandler factionInfo, IUserHandler userHandler, IMemberHandler memberHandler) : Controller {
        private IUserHandler _userHandler = userHandler;
        private IMemberHandler _memberHandler = memberHandler;

        public IActionResult Overview () {
            var info = factionInfo.GetFactionInfo ();

            return View (info);
        }

        public IActionResult StatsOverview () {
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
