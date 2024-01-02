using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class StatusAccess (DbSet<Status> set, DbContext context) : EntityAccess<Status> (set, context), IStatusAccess {
    }
}
