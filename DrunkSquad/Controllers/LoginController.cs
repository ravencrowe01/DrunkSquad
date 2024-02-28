using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Framework.Logic.Users.Login;
using DrunkSquad.Logic.Extensions;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TornApi.Net.Models.User;

namespace DrunkSquad.Controllers {
    public class LoginController (ILoginHandler handler, IUserHandler userHandler, IBattleStatsRegistry battleStatsRegistry, IWorkingStatsRegistry workingStatsRegistry) : Controller {
        private IUserHandler _userHandler = userHandler;
        private IBattleStatsRegistry _battleStatsRegistry = battleStatsRegistry;
        private IWorkingStatsRegistry _workingStatsRegistry = workingStatsRegistry;

        [Route ("login")]
        public IActionResult Login () {
            return View (new LoginAttempt ());
        }

        [HttpPost]
        [Route ("login/attempt")]
        public async Task<IActionResult> Attempt (LoginAttempt login) {
            if (!ModelState.IsValid) {
                // TODO This needs to be better
                return View ();
            }

            var details = new LoginDetails {
                ApiKey = login.ApiKey,
                Password = login.Password
            };

            switch (handler.AttemptLogin (details)) {
                case PasswordVerificationResult.Success:
                case PasswordVerificationResult.SuccessRehashNeeded:
                    var claims = handler.BuildUserClaims (details);

                    var claimsIdentity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties {
                        ExpiresUtc = new DateTimeOffset (DateTime.UtcNow.AddMinutes (1440)),
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync (CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal (claimsIdentity), authProperties);

                    var authResult = await HttpContext.AuthenticateAsync ();

                    var idClaim = claims.FirstOrDefault (claims => claims.Type == "TornID");

                    if (idClaim is not null) {
                        var id = int.Parse (idClaim.Value);
                        var user = _userHandler.FindUserbyID (id);

                        var battleStats = await _userHandler.FetchBattleStats (details.ApiKey);

                        if (battleStats.IsValid ()) {
                            user.BattleStats ??= new BattleStats ();

                            user.BattleStats.Update (battleStats.Content);
                            _battleStatsRegistry.Update (user.BattleStats);
                        }

                        var workingStats = await _userHandler.FetchWorkingStats (details.ApiKey);

                        if (battleStats.IsValid ()) {
                            user.WorkingStats ??= new WorkingStats ();

                            user.WorkingStats.Update (workingStats.Content);
                            _workingStatsRegistry.Update (user.WorkingStats);
                        }
                    }

                    return RedirectToAction ("Index", "Home");
                case PasswordVerificationResult.Failed:
                    return View ("Login", new LoginAttempt {
                        ApiKey = login.ApiKey,
                        PreviousAttempt = PasswordVerificationResult.Failed
                    });
                default:
                    return RedirectToAction ("Index", "Home");
            }
        }

        public async Task<IActionResult> Logout () {
            await HttpContext.SignOutAsync (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction ("Index", "Home");
        }

        private async Task FetchUserStats (string key) {
            var battleStats = await _userHandler.FetchBattleStats (key);
            var workingStats = await _userHandler.FetchWorkingStats (key);
        }
    }
}
