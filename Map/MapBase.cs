using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Map
{
    public abstract class MapBase
    {
        public readonly int Id;
        public readonly string? Name;

        public MapBase(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
