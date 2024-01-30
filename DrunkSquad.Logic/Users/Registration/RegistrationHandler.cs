﻿using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users.Registration;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.AspNetCore.Identity;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users.Registration {
    public class RegistrationHandler (IPasswordHasher<LoginDetails> hasher, IApiRequestClient apiClient, IWebsiteConfig config, IUserAccess userAccess, IProfileAccess profileAccess) : IRegistrationHandler {
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

            newUser.Profile = profile is not null ? profile : result.Content;
            newUser.LoginDetails = details;
            newUser.LoginDetails.Password = _hasher.HashPassword (details, details.Password);
            //newUser.WebsiteRole = DetermineUserRole (result.Content);

            userAccess.Add (newUser);

            return RegistrationStatus.Registered;
        }

        private UserRole DetermineUserRole (int id, Position position) {
            //var test = profile.ProfileID == config.Faction.Leader || profile.ProfileID == config.Faction.CoLeader ?0
            var role = UserRole.User;

            if(id == config.Faction.Leader || id == config.Faction.CoLeader) {
                return UserRole.Admin;
            }

            if(position.CanKickMembers == 1 || position.CanAdjustMemberBalance == 1 || position.CanManageWars == 1 || position.CanManageUpgrades == 1) {

            }

            return role;
        }
    }
}
