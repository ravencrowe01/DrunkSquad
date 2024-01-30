using DrunkSquad.Database.Accessors;
using DrunkSquad.Framework.Logic.Users;
using DrunkSquad.Models.Config;
using DrunkSquad.Models.Users;
using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;
using TornApi.Net.REST;

namespace DrunkSquad.Logic.Users; 
#pragma warning disable CS9113 // Parameter is unread.
public class UserHandler (IApiRequestClient client, IWebsiteConfig config, IUserAccess userAccess) : IUserHandler {
    public void AddUser (User user) => userAccess.Add (user);

    public void AddUsers (IEnumerable<User> users) => userAccess.AddRange (users);

    public IEnumerable<User> GetAllUsers () => userAccess.Set.Include (user => user.Profile);

    public User FindUserbyID (int id) => userAccess.FindByProfileID (id);
}

public class MemberHandler (IApiRequestClient client, IWebsiteConfig config, IMemberAccess memberAccess) : IMemberHandler {
    public IEnumerable<Member> GetAllMembers () => memberAccess.Set.ToList ();

    public Member GetMemberByProfileID (int id) => memberAccess.FindMemberByProfileID (id);
}
#pragma warning restore CS9113 // Parameter is unread.

