using DrunkSquad.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public interface ICrimeExperienceEntryAccess : IEntityAccess<CrimeExperienceEntry> {
        void AddCE (CrimeExperienceEntry entry);
    }
}
