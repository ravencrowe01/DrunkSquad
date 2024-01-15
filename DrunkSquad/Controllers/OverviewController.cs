using DrunkSquad.Logic.Faction.Info;
using Microsoft.AspNetCore.Mvc;

namespace DrunkSquad.Controllers {
    public class OverviewController(IFactionInfoHandler factionInfo) : Controller {
        public IActionResult Overview () {
            var authCookie = HttpContext.Request.Cookies [".AspNetCore.Cookies"];

            var claims = HttpContext.User.Claims;

            var key = claims.First (c => c.Type == "ApiKey");
            return View ();
        }
    }
}
