using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day24
{
    class Component
    {
        // if we do this recursively we probably don't need a separate "Port" class.
        // simply use two int's and whether or not the component is in use.
        public List<Port> Ports { get; set; }
    }
}
