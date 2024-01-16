using DrunkSquad.Models.Faction;
using TornApi.Net.Models.Faction;

namespace DrunkSquad.Logic.Extensions {
    public static class CrimeExtensions {
        public static FactionCrime ToFactionCrime (this Crime crime) => new FactionCrime {
            CrimeID = crime.CrimeID,
            CrimeType = crime.CrimeType,
            Name = crime.Name,
            Initiated = crime.Initiated,
            InitiatedBy = crime.InitiatedBy,
            MoneyGain = crime.MoneyGain,
            Participants = crime.Participants,
            PlannedBy = crime.PlannedBy,
            RespectGain = crime.RespectGain,
            Success = crime.Success,
            TimeComplete = crime.TimeComplete,
            TimeLeft = crime.TimeLeft,
            TimeReady = crime.TimeReady,
            TimeStarted = crime.TimeStarted,
        };
    }
}
