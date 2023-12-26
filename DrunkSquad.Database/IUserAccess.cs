using DrunkSquad.Models.Users;

namespace DrunkSquad.Database {
    public interface IUserAccess : IEntityAccess<User> {
        User FindByApiKey (string key);
    }
}