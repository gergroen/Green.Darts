using Green.Darts.Model.Event;

namespace Green.Darts.Hub
{
    public class PlayerHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public void NewPlayerCreatedEvent(NewPlayerCreatedEvent newPlayerCreatedEvent)
        {
            Clients.All.NewPlayerCreatedEvent(newPlayerCreatedEvent);
        }
    }
}
