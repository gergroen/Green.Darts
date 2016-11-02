using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Green.Darts.Model
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAll();
        void Save(Player player);
        Task<Player> Get(Guid id);
    }
}
