using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class FactionCrimeAccess (DbSet<FactionCrime> set, DbContext context) : EntityAccess<FactionCrime> (set, context), IFactionCrimeAccess {
        public FactionCrime FindByCrimeID (int id) => _set.FirstOrDefault (crime => crime.CrimeID == id);

        public void UpdateCrime (FactionCrime crime) {
            var found = _set.FirstOrDefault (c => c.CrimeID == crime.CrimeID);

            if(found is not null) {
                found.Update (crime);

                _context.SaveChanges ();
            } else {
                Add (crime);
            }
        }
    }
}
