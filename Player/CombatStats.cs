using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGameFramework.Player;

public class CombatStats
{
    public int BaseAttack { get; private set; }
    public int BaseDefence { get; private set; }
  

    public CombatStats(int attack,int defence)
    {
        BaseAttack = attack;
        BaseDefence = defence;
    }
      
}

