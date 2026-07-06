using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Item
{


    public class Sword : ItemBase, IEquipable
    {

        public Sword() : base(001, "강철 검")
        {
        }

        public void Equip()
        {

        }
    }

    public class Armor : ItemBase, IEquipable
    {
        public Armor() : base(002, "철 갑옷")
        {

        }
        public void Equip()
        {

        }
    }





}