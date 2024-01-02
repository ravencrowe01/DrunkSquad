using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class MarriageAccess (DbSet<Marriage> set, DbContext context) : EntityAccess<Marriage> (set, context), IMarriageAccess {
    }
}
