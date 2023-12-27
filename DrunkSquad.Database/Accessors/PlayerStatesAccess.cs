using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class PlayerStatesAccess (DbSet<PlayerStates> set, DbContext context) : EntityAccess<PlayerStates> (set, context), IPlayerStatesAccess {
    }
}
