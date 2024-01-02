using DrunkSquad.Models.Users;

namespace DrunkSquad.Database.Accessors {
    public interface IUserAccess : IEntityAccess<User> {
        User FindByApiKey (string key);
    }
}
