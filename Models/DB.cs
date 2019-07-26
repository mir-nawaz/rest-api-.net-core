using Microsoft.EntityFrameworkCore;

namespace restCore.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {}

        public DbSet<Command> Command {get; set;}
    }
}