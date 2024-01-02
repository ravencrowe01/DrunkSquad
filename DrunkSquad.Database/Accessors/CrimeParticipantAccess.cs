using DrunkSquad.Models.Faction;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.Database.Accessors {
    public class CrimeParticipantAccess (DbSet<CrimeParticipant> set, DbContext context) : EntityAccess<CrimeParticipant> (set, context), ICrimeParticipantAccess {
    }
}
