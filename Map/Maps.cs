using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Map
{
    public class GrassField : MapBase
    {
        public GrassField() : base(001, "초원",1)
        {
            NextMapId = 002;
        }
    }
    public class Forest : MapBase
    {
        public Forest() : base(002, "숲",3)
        {

        }
    }
    public class Grave : MapBase
    {
        public Grave() : base(003, "묘지",6)
        {

        }
    }
    
    public class Castle : MapBase
    {
        public Castle() : base(005, "마왕성",9)
        {

        }
    }
}
