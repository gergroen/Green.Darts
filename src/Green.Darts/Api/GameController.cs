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
    public class GameController : Controller
    {
        private IHubContext _gameHub;
        private IGameRepository _gameRepository;

        public GameController(IConnectionManager connectionManager, IGameRepository gameRepository)
        {
            _gameHub = connectionManager.GetHubContext<GameHub>();
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<Game> Get(Guid id)
        {
            return await _gameRepository.Get(id);
        }

        [HttpGet]
        public async Task<List<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        [HttpPost]
        public void StartNewGame([FromBody]StartNewGameCommand startNewGameCommand)
        {
            var game = new Game
            {
                //Id = Guid.NewGuid(),
                Name = startNewGameCommand.Name
            };
            _gameRepository.Save(game);
            _gameHub.Clients.All.NewGameStartedEvent(new NewGameStartedEvent { GameId = game.Id });
        }
    }
}
