using Green.Darts.Hub;
using Green.Darts.Model;
using Green.Darts.Model.Command;
using Green.Darts.Model.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Green.Darts.Api
{
    [Route("api/[controller]/[action]")]
    public class PlayerController : Controller
    {
        private IHubContext _playerHub;
        private IPlayerRepository _playerRepository;

        public PlayerController(IConnectionManager connectionManager, IPlayerRepository playerRepository)
        {
            _playerHub = connectionManager.GetHubContext<PlayerHub>();
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<Player> Get(Guid id)
        {
            return await _playerRepository.Get(id);
        }

        [HttpGet]
        public async Task<List<Player>> GetAll()
        {
            return await _playerRepository.GetAll();
        }

        [HttpPost]
        public void CreateNewPlayer([FromBody]CreateNewPlayerCommand createNewPlayerCommand)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = createNewPlayerCommand.Name
            };
            _playerRepository.Save(player);
            _playerHub.Clients.All.NewPlayerCreatedEvent(new NewPlayerCreatedEvent { PlayerId = player.Id });
        }
    }
}
