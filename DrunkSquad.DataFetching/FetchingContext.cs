using DrunkSquad.Database;
using Microsoft.EntityFrameworkCore;

namespace DrunkSquad.DateFetching {
    internal class FetchingContext (string connectionString) : DrunkSquadDBContext {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer (connectionString);
            base.OnConfiguring (optionsBuilder);
        }
    }
}