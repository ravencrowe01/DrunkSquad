using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class CrimeExperienceEntryAccess (DbSet<CrimeExperienceEntry> set, DbContext context) : EntityAccess<CrimeExperienceEntry> (set, context), ICrimeExperienceEntryAccess {
        public void AddCE (CrimeExperienceEntry entry) {
            if(!_set.Any(cee => cee.Member == entry.Member)) {
                Add (entry);
            }
        }
    }
}
