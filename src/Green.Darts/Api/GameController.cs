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
    public class GameController : Controller
    {
        private IHubContext _gameHub;
        private static List<Game> _games = new List<Game>();

        public GameController(IConnectionManager connectionManager)
        {
            _gameHub = connectionManager.GetHubContext<GameHub>();
        }

        [HttpGet]
        public Game Get(Guid id)
        {
            return _games.Single(x => x.Id == id);
        }

        [HttpGet]
        public List<Game> GetAll()
        {
            return _games;
        }

        [HttpPost]
        public void StartNewGame([FromBody]StartNewGameCommand startNewGameCommand)
        {
            var game = new Game
            {
                Id = Guid.NewGuid(),
                Name = startNewGameCommand.Name
            };
            _games.Add(game);
            _gameHub.Clients.All.NewGameStartedEvent(new NewGameStartedEvent { GameId = game.Id });
        }
    }
}
