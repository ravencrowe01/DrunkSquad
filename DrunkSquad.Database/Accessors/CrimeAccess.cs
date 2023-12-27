using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public class CrimeAccess (DbSet<Crime> set, DbContext context) : EntityAccess<Crime>(set, context), ICrimeAccess {
    }
}
