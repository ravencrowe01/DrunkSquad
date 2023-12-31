﻿using Microsoft.AspNetCore.Identity;

namespace DrunkSquad.Models.Users {
    public class LoginAttempt : LoginDetails {
        public PasswordVerificationResult Result { get; set; }

        public bool AttemptFailed { get; set; }
    }
}
