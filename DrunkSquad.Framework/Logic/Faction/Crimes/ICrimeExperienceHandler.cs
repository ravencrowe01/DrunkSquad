using DrunkSquad.Models.Faction;

namespace DrunkSquad.Framework.Logic.Faction.Crimes;

public interface ICrimeExperienceHandler {
    void AddCrimeExperience (CrimeExperienceEntry entry);

    Task<IEnumerable<CrimeExperienceEntry>> FetchCrimeExperience ();

    IEnumerable<CrimeExperienceEntry> GetCrimeExperience ();
}
