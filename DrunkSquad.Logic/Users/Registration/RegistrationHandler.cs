using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users.Registration;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users.Registration {
    public class RegistrationHandler (IPasswordHasher<LoginDetails> hasher, IApiRequestClient apiClient, IWebsiteConfig config, IUserAccess userAccess, IProfileAccess profileAccess, IMemberAccess memberAccess, IPositionAccess positionAccess) : IRegistrationHandler {
        private IPasswordHasher<LoginDetails> _hasher = hasher;
        private static readonly string [] selections = ["profile"];

        public async Task<RegistrationStatus> RegisterAsync (LoginDetails details) {
            var found = userAccess.FindByApiKey (details.ApiKey);

            if (found is not null) {
                return RegistrationStatus.KeyInUse;
            }

            var requiredLevel = config.Api.RequiredAccessLevel;

            var result = await apiClient.GetAsync<Profile> (new RequestConfiguration {
                Key = details.ApiKey,
                Section = "user",
                Selections = selections,
                Comment = "Drunk Squad User Registration"
            },
            requiredLevel);

            if (!result.KeyStatus.IsKeyUsable) {
                return RegistrationStatus.InvalidKey;
            }

            if (result.HttpResponseMessage is null || !result.HttpResponseMessage.IsSuccessStatusCode) {
                return RegistrationStatus.InvalidApiResponse;
            }

            if (result.Content is null) {
                return RegistrationStatus.NoResponse;
            }

            found = userAccess.FindByProfileID (result.Content.ProfileID);

            if (found is not null) {
                return RegistrationStatus.AlreadyRegistered;
            }

            var newUser = new User ();
            var profile = profileAccess.FindByProfileID (result.Content.ProfileID);
            var member = memberAccess.FindMemberByProfileID (result.Content.ProfileID);
            var position = positionAccess.FindPositionByName (member.Position);

            newUser.Profile = profile is not null ? profile : result.Content;
            newUser.LoginDetails = details;
            newUser.LoginDetails.Password = _hasher.HashPassword (details, details.Password);
            newUser.WebsiteRole = DetermineUserRole (result.Content.ProfileID, position);
            newUser.Position = position;

            userAccess.Add (newUser);

            return RegistrationStatus.Registered;
        }

        private UserRole DetermineUserRole (int id, Position position) {
            if(id == config.Faction.Leader || id == config.Faction.CoLeader) {
                return UserRole.Owner;
            }

            if(position.CanKickMembers == 1 || position.CanAdjustMemberBalance == 1 || position.CanManageWars == 1 || position.CanManageUpgrades == 1) {
                return UserRole.Admin;
            }

            return UserRole.User;
        }
    }
}
