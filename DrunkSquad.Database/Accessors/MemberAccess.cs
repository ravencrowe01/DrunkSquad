using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Database.Accessors {
    public class MemberAccess (DbSet<Member> set, DbContext context) : EntityAccess<Member> (set, context), IMemberAccess {
        public Member FindMemberByProfileID (int id) => _set.FirstOrDefault (member => member.MemberID == id);
    }
}
