using DrunkSquad.Models.Users;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public interface IUserHandler {
        Task<IApiResponse<User>> FetchUserAsync (string key, int id);
        void AddUser (User user);
        void AddUsers (IEnumerable<User> users);
    }
}