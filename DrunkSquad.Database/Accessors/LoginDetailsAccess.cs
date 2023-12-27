using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class LoginDetailsAccess (DbSet<LoginDetails> set, DbContext context) : EntityAccess<LoginDetails> (set, context), ILoginDetailsAccess {
    }
}
