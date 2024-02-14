using DrunkSquad.Framework.Logic.Faction.Info;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class OverviewController (IFactionInfoHandler factionInfo) : Controller {
        public IActionResult Overview () {
            var info = factionInfo.GetFactionInfo ();

            return View (info);
        }
    }
}
