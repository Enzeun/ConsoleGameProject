using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Map
{
    public abstract class MapBase
    {
        public readonly MapKey Key;
        //public readonly int Id;
        public readonly string? Name;
        public readonly int EnterLevel;
        //public int NextMapId {  get; protected set; }
        public MapKey NextMapKey {  get; protected set; }

        public MapBase(MapKey key, string name, int enterLever)
        {
            Key = key;
            //Id = id;
            Name = name;
            EnterLevel = enterLever;

        }
    }
}
