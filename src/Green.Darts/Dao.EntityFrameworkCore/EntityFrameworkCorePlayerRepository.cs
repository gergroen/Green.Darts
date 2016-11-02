using Green.Darts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Green.Darts.Dao.EntityFrameworkCore
{
    public class EntityFrameworkCorePlayerRepository : EntityFrameworkCoreBaseRepository, IPlayerRepository
    {
        public EntityFrameworkCorePlayerRepository(DartsDbContext context) 
            : base(context)
        {
        }

        public Task<Player> Get(Guid id)
        {
            return Context.Players.SingleOrDefaultAsync(player => player.Id == id);
        }

        public Task<List<Player>> GetAll()
        {
            return Context.Players.ToListAsync();
        }

        public void Save(Player player)
        {
            Context.Players.Add(player);
            Context.SaveChanges();
        }
    }
}
