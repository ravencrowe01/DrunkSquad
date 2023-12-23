using DrunkSquad.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkSquad.Database {
    public class DBAccess : DbContext {
        public DbSet<DSUser> Users { get; set; }
        public UserAccess UserAccess => new UserAccess (Users);
    }
}
