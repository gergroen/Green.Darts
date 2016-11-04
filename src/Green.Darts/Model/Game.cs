using System;
using System.Collections.Generic;

namespace Green.Darts.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public List<Round> Rounds { get; set; }
    }
}
