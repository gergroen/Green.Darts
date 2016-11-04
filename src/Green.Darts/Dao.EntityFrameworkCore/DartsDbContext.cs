using Green.Darts.Model;
using Microsoft.EntityFrameworkCore;

namespace Green.Darts.Dao.EntityFrameworkCore
{
    public class DartsDbContext : DbContext
    {
        public DartsDbContext(DbContextOptions<DartsDbContext> options)
            : base(options)
        { }

        //public DbSet<Club> Club { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }


        //public DbSet<Federation> Federations { get; set; }
        //public DbSet<Competition> Competitions { get; set; }
        //public DbSet<Division> Divisions { get; set; }
        public DbSet<Game> Games { get; set; }

    }
}
