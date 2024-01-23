using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Framework.Logic.Users {
    public interface IProfileHandler {
        void AddProfile (Profile profile);
        void AddProfiles (IEnumerable<Profile> profiles);
        Task<IApiResponse<Profile>> FetchProfileAsync (int id);
        Profile GetProfile (int id);
        IEnumerable<Profile> GetAllProfiles ();
    }
}