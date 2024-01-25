using DrunkSquad.Models.Users;

namespace DrunkSquad.Logic.Extensions;

public static class StringExtensions {
    public static UserRole ToUserRole (this string roleString) => roleString switch {
        "User" => UserRole.User,
        "Admin" => UserRole.Admin,
        "Owner" => UserRole.Owner,
        _ => throw new NotImplementedException (),
    };
}
