using System.Collections.Generic;
using Green.Darts.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Green.Darts.Dao.EntityFrameworkCore
{
    public class EntityFrameworkCoreGameRepository : EntityFrameworkCoreBaseRepository, IGameRepository
    {
        public EntityFrameworkCoreGameRepository(DartsDbContext context) 
            : base(context)
        {
        }

        public Task<Game> Get(Guid id)
        {
            return Context.Games.SingleOrDefaultAsync(game => game.Id ==  id);
        }

        public Task<List<Game>> GetAll()
        {
            return Context.Games.ToListAsync();
        }

        public void Save(Game game)
        {
            Context.Games.Add(game);
            Context.SaveChanges();
        }
    }
}
