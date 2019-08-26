using Microsoft.EntityFrameworkCore;

namespace restCore.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Command> Command { get; set; }
        public DbSet<JwtToken> JwtToken { get; set; }
    }
}