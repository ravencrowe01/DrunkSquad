using DrunkSquad.Models.Users;
using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Framework.Logic.Users {
    public interface IUserHandler {
        void AddUser (User user);
        void AddUsers (IEnumerable<User> users);
        Task<IApiResponse<BattleStats>> FetchBattleStats (string key);
        Task<IApiResponse<WorkingStats>> FetchWorkingStats (string key);
        User FindUserbyID (int id);
        IEnumerable<User> GetAllUsers ();
        void UpdateUser (User user);
    }
}