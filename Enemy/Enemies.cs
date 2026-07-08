using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;

// -----------------------아래는 Enemy 종류------------------------------


public class Slime : EnemyBase
{
    public Slime() : base("슬라임", 50)
    {
        Attack = 10;
        Defence = 8;
        Exp = 30;
    }

    public override string Image()
    {
        return (@" 
                                         ___
                                        /  /
                                       /    \
                                      / o o  \
                                     (   -    )
                                      \______/
            ");
    }
}
public class Wolf : EnemyBase
{
    public Wolf() : base("늑대(?)", 70)
    {
        Attack = 20;
        Defence = 2;
        Exp = 40;

    }

    public override string Image()
    {
        return (@" 
                                    /\_____/\
                                   /  o   o  \
                                  ( ==  ^  == )
                                   )         (
            ");
    }
}

public class Goblin : EnemyBase
{
    public Goblin() : base("고블린", 100)
    {
        Attack = 15;
        Defence = 4;
        Exp = 50;

    }
    public override string Image()
    {
        return (@" 
                                       __
                                     _/  \_
                                    / @ @  \
                                   | <___>  |
                                   | \___/  |
                                    \ WWW  /
                                     \____/                      
            ");
    }
}

