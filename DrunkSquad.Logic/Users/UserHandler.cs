using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Key;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users;
#pragma warning disable CS9113 // Parameter is unread.
public class UserHandler (IApiRequestClient client, IWebsiteConfig config, IUserAccess userAccess, IBattleStatsRegistry battleStats, IWorkingStatsRegistry workingStats) : IUserHandler {
    private IApiRequestClient _client = client;

    private IBattleStatsRegistry _battleStats = battleStats;

    private IWorkingStatsRegistry _workingStats = workingStats;

    public void AddUser (User user) => userAccess.Add (user);

    public void AddUsers (IEnumerable<User> users) => userAccess.AddRange (users);

    public IEnumerable<User> GetAllUsers () => userAccess.Set.Include (user => user.Profile)
        .Include (user => user.BattleStats)
        .Include (user => user.WorkingStats);

    public User FindUserbyID (int id) => userAccess.FindByProfileID (id);

    public void UpdateUser (User user) {
        userAccess.Update (user);
    }

    public async Task<IApiResponse<BattleStats>> FetchBattleStats (string key) {
        var requestConfig = new RequestConfiguration {
            Key = key,
            Section = "user",
            Selections = ["battlestats"],
            Comment = "DrunkSquad Battle Stats Fetch"
        };

        var response = await _client.GetAsync<BattleStats> (requestConfig, AccessLevel.LimitedAccess);

        return response;
    }

    public async Task<IApiResponse<WorkingStats>> FetchWorkingStats (string key) {
        var requestConfig = new RequestConfiguration {
            Key = key,
            Section = "user",
            Selections = ["workstats"],
            Comment = "DrunkSquad Work Stats Fetch"
        };

        var response = await _client.GetAsync<WorkingStats> (requestConfig, AccessLevel.LimitedAccess);

        return response;
    }
}
#pragma warning restore CS9113 // Parameter is unread.

