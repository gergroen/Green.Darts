using System;

namespace Green.Darts.Model.Event
{
    public class NewGameStartedEvent
    {
        public Guid GameId { get; set; }
    }
}
