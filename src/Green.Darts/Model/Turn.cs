using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Green.Darts.Model
{
    public class Turn
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Player Player { get; set; }
        public List<Throw> Throws { get; set; }
    }
}
