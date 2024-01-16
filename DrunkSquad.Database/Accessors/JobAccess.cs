using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class JobAccess (DbSet<Job> set, DbContext context) : EntityAccess<Job> (set, context), IJobAccess {
    }
}
