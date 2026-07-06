using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Map
{
    public class Field : MapBase
    {
        public Field() : base(001, "초원")
        {

        }
    }
    public class Forest : MapBase
    {
        public Forest() : base(002, "숲")
        {

        }
    }
}
