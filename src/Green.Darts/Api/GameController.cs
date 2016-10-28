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
    public class GameController : Controller
    {
        private IHubContext _gameHub;

        public GameController(IConnectionManager connectionManager)
        {
            _gameHub = connectionManager.GetHubContext<GameHub>();
        }

        [HttpPost]
        public void StartNewGame([FromBody]StartNewGameCommand startNewGameCommand)
        {
            _gameHub.Clients.All.NewGameStartedEvent(new NewGameStartedEvent { GameId = Guid.NewGuid() });
        }
    }
}
