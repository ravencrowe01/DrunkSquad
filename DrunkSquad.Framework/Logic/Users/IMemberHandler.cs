using TornApi.Net.Models.Faction;

namespace DrunkSquad.Framework.Logic.Users;

public interface IMemberHandler {
    IEnumerable<Member> GetAllMembers ();
    Member GetMemberByProfileID (int id);
}
