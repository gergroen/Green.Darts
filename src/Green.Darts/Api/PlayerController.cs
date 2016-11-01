using Green.Darts.Hub;
using Green.Darts.Model;
using Green.Darts.Model.Command;
using Green.Darts.Model.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Green.Darts.Api
{
    [Route("api/[controller]/[action]")]
    public class PlayerController : Controller
    {
        private IHubContext _playerHub;
        private static List<Player> _players = new List<Player>();

        public PlayerController(IConnectionManager connectionManager)
        {
            _playerHub = connectionManager.GetHubContext<PlayerHub>();
        }

        [HttpGet]
        public Player Get(Guid id)
        {
            return _players.Single(x => x.Id == id);
        }

        [HttpGet]
        public List<Player> GetAll()
        {
            return _players;
        }

        [HttpPost]
        public void CreateNewPlayer([FromBody]CreateNewPlayerCommand createNewPlayerCommand)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = createNewPlayerCommand.Name
            };
            _players.Add(player);
            _playerHub.Clients.All.NewPlayerCreatedEvent(new NewPlayerCreatedEvent { PlayerId = player.Id });
        }
    }
}
