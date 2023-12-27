using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.User;

namespace DrunkSquad.Database.Accessors {
    public class FactionStubAccess (DbSet<FactionStub> set, DbContext context) : EntityAccess<FactionStub> (set, context), IFactionStubAccess {
    }
}
