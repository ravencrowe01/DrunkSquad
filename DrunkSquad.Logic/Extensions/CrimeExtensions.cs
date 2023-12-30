using DrunkSquad.Models.Faction;
using DrunkSquad.Models.Users;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Extensions {
    public static class CrimeExtensions {
        public static FactionCrime ToFactionCrime (this Crime crime, IEnumerable<User> participants, int id) {
            return new FactionCrime {
                FactionID = crime.FactionID,
                FactionCrimeID = id,
                CrimeType = crime.CrimeType,
                Name = crime.Name,
                Initiated = crime.Initiated,
                InitiatedBy = crime.InitiatedBy,
                MoneyGain = crime.MoneyGain,
                PlannedBy = crime.PlannedBy,
                RespectGain = crime.RespectGain,
                Success = crime.Success,
                TimeComplete = crime.TimeComplete,
                TimeLeft = crime.TimeLeft,
                TimeReady = crime.TimeReady,
                TimeCreated = crime.TimeCreated,
                Participants = participants
            };
        }
    }
}
