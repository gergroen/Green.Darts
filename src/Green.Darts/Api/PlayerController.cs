using Green.Darts.Hub;
using Green.Darts.Model.Command;
using Green.Darts.Model.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using System;

namespace Green.Darts.Api
{
    [Route("api/[controller]/[action]")]
    public class PlayerController : Controller
    {
        private IHubContext _playerHub;

        public PlayerController(IConnectionManager connectionManager)
        {
            _playerHub = connectionManager.GetHubContext<PlayerHub>();
        }

        [HttpPost]
        public void CreateNewPlayer([FromBody]CreateNewPlayerCommand createNewPlayerCommand)
        {
            _playerHub.Clients.All.NewPlayerCreatedEvent(new NewPlayerCreatedEvent { PlayerId = Guid.NewGuid() });
        }
    }
}
