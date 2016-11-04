using System;
using System.Collections.Generic;

namespace Green.Darts.Model
{
    public class Round
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int BestOfLegs { get; set; }
        public int BestOfSets { get; set; }
        public bool DoubleIn { get; set; }
        public bool DoubleOut { get; set; }
        public int StartPoints { get; set; }
        public List<Player> Players { get; set; }
        public List<Set> Sets { get; set; }
    }
}
