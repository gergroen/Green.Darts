using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Green.Darts.Model
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAll();
        void Save(Game game);
        Task<Game> Get(Guid id);
    }
}
