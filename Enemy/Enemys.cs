using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;

// -----------------------아래는 Enemy 종류------------------------------


public class Slime : EnemyBase
{
    public Slime() : base("슬라임", 50,10,8)
    {

    }

    public override string Image()
    {
        return (@" 
                                         _/_
                                        /   \
                                      / o o  \
                                     (        )
                                      \______/
            ");
    }
}
public class Wolf : EnemyBase
{
    public Wolf() : base("늑대", 70,20,2)
    {

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
    public Goblin() : base("고블린", 100,15,4)
    {

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

