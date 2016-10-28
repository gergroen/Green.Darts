using System;

namespace Green.Darts.Model.Event
{
    public class NewPlayerCreatedEvent
    {
        public Guid PlayerId { get; set; }
    }
}
