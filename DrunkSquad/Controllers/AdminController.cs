using DrunkSquad.Framework.Logic.Faction.Info;
using DrunkSquad.Logic.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrunkSquad.Controllers {
    public class AdminController (IFactionInfoHandler factionInfoHandler) : Controller {
        private IFactionInfoHandler _factionInfoHandler = factionInfoHandler;

        public async Task<IActionResult> AdminOverview () {
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

            var info = _factionInfoHandler.GetFactionInfo ();

            return View (info);
        }
    }
}
