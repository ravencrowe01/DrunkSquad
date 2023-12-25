using DrunkSquad.Models.User;

namespace DrunkSquad.Database {
    public interface IUserAccess : IEntityAccess<User> {
        User FindByApiKey (string key);
    }
}