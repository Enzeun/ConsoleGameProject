using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Map
{
    public class GrassField : MapBase
    {
        public GrassField() : base(MapKey.GrassField, "초원", 1)
        {
            NextMapKey = MapKey.Forest;
            //NextMapId = 002;
        }
    }
    public class Forest : MapBase
    {
        public Forest() : base(MapKey.Forest, "숲", 3)
        {
            NextMapKey = MapKey.Cave;
            //NextMapId = 003;
        }
    }
    public class Grave : MapBase
    {
        public Grave() : base(MapKey.Cave, "묘지", 6)
        {
            NextMapKey = MapKey.Castle;
            //NextMapId = 004;
        }
    }

    public class Castle : MapBase
    {
        public Castle() : base(MapKey.Castle, "마왕성", 9)
        {
            NextMapKey = MapKey.Dummy;
            //NextMapId = 999;
        }
    }
    public class Dummy : MapBase
    {
        public Dummy() : base(MapKey.Dummy, "이 곳은 없는 맵입니다", 999)
        {
            //NextMapId = 999;
        }
    }
}
