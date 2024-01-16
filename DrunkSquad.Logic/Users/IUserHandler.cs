using DrunkSquad.Models.Users;

namespace DrunkSquad.Logic.Users {
    public interface IUserHandler {
        void AddUser (User user);
        void AddUsers (IEnumerable<User> users);
        IEnumerable<User> GetAllUsers ();
    }
}