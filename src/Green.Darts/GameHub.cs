using Microsoft.AspNetCore.SignalR;
using System;

namespace Green.Darts
{
    public class GameHub : Hub
    {
        public void NewGameStartedEvent(NewGameStartedEvent newGameStartedEvent)
        {
            Clients.All.NewGameStartedEvent(newGameStartedEvent);
        }
    }

    public class NewGameStartedEvent
    {
        public Guid GameId { get; set; }
    }
}
