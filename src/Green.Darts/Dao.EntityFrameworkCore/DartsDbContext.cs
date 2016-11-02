using Green.Darts.Model;
using Microsoft.EntityFrameworkCore;

namespace Green.Darts.Dao.EntityFrameworkCore
{
    public class DartsDbContext : DbContext
    {
        public DartsDbContext(DbContextOptions<DartsDbContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
