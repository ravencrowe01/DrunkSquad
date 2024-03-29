﻿using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public class ProfileHandler (IApiRequestClient client, IWebsiteConfig config, IProfileAccess profileAccess) : IProfileHandler {
        public async Task<IApiResponse<Profile>> FetchProfileAsync (int id) {
            var requestConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                ID = id,
                Section = "user",
                Selections = ["profile"],
                Comment = "Drunk Squad Profile Fetch"
            };

            var response = await client.GetAsync<Profile> (requestConfig, config.Api.RequiredAccessLevel);

            return response;
        }

        public void AddProfile (Profile profile) {
            if (profileAccess.FindByProfileID (profile.ProfileID) is null) {
                profileAccess.Add (profile);
            }
        }

        public void AddProfiles (IEnumerable<Profile> profiles) {
            foreach (var profile in profiles) {
                AddProfile (profile);
            }
        }

        public Profile GetProfile (int id) => profileAccess.FindByProfileID (id);

        public IEnumerable<Profile> GetAllProfiles () => profileAccess.Set.ToList ();

        public async Task<UserCrimesStats> FetchProfileCrimeStatsAsync (int id) {
            var requestConfig = new RequestConfiguration {
                Key = config.Api.DefaultKey,
                ID = id,
                Section = "user",
                Selections = ["crimes"],
                Comment = "DrunkSquad User Crimes Fetch"
            };

            var response = await client.GetAsync<UserCrimesStats> (requestConfig, config.Api.RequiredAccessLevel);

            return response.Content;
        }
    }
}
