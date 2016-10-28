using System;

namespace Green.Darts.Model.Command
{
    public class StartNewGameCommand
    {
        public string Name { get; set; }
        public Guid PlayerOneId { get; set; }
        public Guid PlayerTwoId { get; set; }
    }
}
