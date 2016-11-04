using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Green.Darts.Model
{
    public class Set
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Leg> Legs { get; set; }
    }
}
