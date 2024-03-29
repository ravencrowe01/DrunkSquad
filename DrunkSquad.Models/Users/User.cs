﻿using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;
using TornApi.Net.Models.User;

namespace DrunkSquad.Models.Users {
    public class User {
        public int ID { get; set; }

        public Profile Profile { get; set; }

        public LoginDetails LoginDetails { get; set; } = new LoginDetails ();

        public UserRole WebsiteRole { get; set; }

        public Position Position { get; set; }

        public UserCrimesStats Crimes { get; set; }

        public BattleStats BattleStats { get; set; }

        public WorkingStats WorkingStats { get; set; }
    }

    public class UserOverview {
        public UserCrimes Crimes { get; set; }

        public StatsOverview Stats { get; set; }
    }
}
