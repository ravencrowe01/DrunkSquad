using TornApi.Net.Models.User;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users {
    public interface IProfileHandler {
        void AddProfile (Profile profile);
        Task<IApiResponse<Profile>> FetchProfileAsync (int id);
    }
}