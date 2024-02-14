using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Config;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users;

#pragma warning disable CS9113 // Parameter is unread.
public class MemberHandler (IApiRequestClient client, IWebsiteConfig config, IMemberAccess memberAccess) : IMemberHandler {
#pragma warning restore CS9113 // Parameter is unread.
    public IEnumerable<Member> GetAllMembers () => memberAccess.Set.ToList ();

    public Member GetMemberByProfileID (int id) => memberAccess.FindMemberByProfileID (id);
}

