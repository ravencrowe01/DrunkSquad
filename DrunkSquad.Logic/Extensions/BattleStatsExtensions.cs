using TornApi.Net.Models.User;

namespace DrunkSquad.Logic.Extensions;

public static class BattleStatsExtensions {
    public static void Update (this BattleStats original, BattleStats other) {
        original.Strength = other.Strength;
        original.Speed = other.Speed;
        original.Dexterity = other.Dexterity;
        original.Defense = other.Defense;
        original.Total = other.Total;
        original.StrengthModifier = other.StrengthModifier;
        original.DefenseModifier = other.DefenseModifier;
        original.SpeedModifier = other.SpeedModifier;
        original.DexterityModifier = other.DexterityModifier;
        original.StrengthInfo = other.StrengthInfo;
        original.DefenseInfo = other.DefenseInfo;
        original.SpeedInfo = other.SpeedInfo;
        original.DexterityInfo = other.DexterityInfo;
    }
}
