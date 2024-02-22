using TornApi.Net.Models.User;

namespace DrunkSquad.Logic.Extensions;

public static class WorkingStatsExtensions {
    public static void Update (this WorkingStats original, WorkingStats other) {
        original.ManualLabor = other.ManualLabor;
        original.Intelligence = other.Intelligence;
        original.Endurance = other.Endurance;
    }
}
