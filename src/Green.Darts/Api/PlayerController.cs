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
        private static List<PlayerDto> _players = new List<PlayerDto>();

        public PlayerController(IConnectionManager connectionManager)
        {
            _playerHub = connectionManager.GetHubContext<PlayerHub>();
        }

        [HttpGet]
        public PlayerDto Get(Guid id)
        {
            return _players.Single(x => x.Id == id);
        }

        [HttpGet]
        public List<PlayerDto> GetAll()
        {
            return _players;
        }

        [HttpPost]
        public void CreateNewPlayer([FromBody]CreateNewPlayerCommand createNewPlayerCommand)
        {
            var player = new PlayerDto
            {
                Id = Guid.NewGuid(),
                Name = createNewPlayerCommand.Name
            };
            _players.Add(player);
            _playerHub.Clients.All.NewPlayerCreatedEvent(new NewPlayerCreatedEvent { PlayerId = player.Id });
        }
    }
}
