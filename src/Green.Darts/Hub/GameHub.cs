using Green.Darts.Model.Event;

namespace Green.Darts.Hub
{
    public class GameHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public void NewGameStartedEvent(NewGameStartedEvent newGameStartedEvent)
        {
            Clients.All.NewGameStartedEvent(newGameStartedEvent);
        }
    }
}
