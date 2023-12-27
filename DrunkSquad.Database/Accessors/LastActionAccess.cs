﻿using Microsoft.EntityFrameworkCore;
using TornApi.Net.Models.Common;

namespace DrunkSquad.Database.Accessors {
    public class LastActionAccess (DbSet<LastAction> set, DbContext context) : EntityAccess<LastAction> (set, context), ILastActionAccess {
    }
}
