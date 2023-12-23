using DrunkSquad.Models.User;

namespace DrunkSquad.Database {
    public interface IUserAccess : IEntityAccess<DSUser> {
        DSUser FindByApiKey (string key);
    }
}