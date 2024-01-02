using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class LastActionAccess (DbSet<LastAction> set, DbContext context) : EntityAccess<LastAction> (set, context), ILastActionAccess {
    }
}
