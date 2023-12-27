using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public class FactionCrimeAccess (DbSet<Crime> set, DbContext context) : EntityAccess<Crime> (set, context), IFactionCrimeAccess {
        public void AddRange (IEnumerable<Crime> crimes) {
            _set.AddRange (crimes);

            _context.SaveChanges ();
        }
    }
}
