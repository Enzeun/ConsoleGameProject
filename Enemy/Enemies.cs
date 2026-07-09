using ConsoleGameFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;

// -----------------------아래는 Enemy 종류------------------------------


public class Slime : EnemyBase
{
    public Slime() : base("슬라임", 150)
    {
        Attack = 50;
        Defence = 8;
        Exp = 30;

        DropTable = new()
        {
            { 111,10 }, //포션
            { 116,10 },

            { 002,5 }, //무기
            { 006,5 },

            { 012,5 }, //방어구
        };
    }

    public override string Image()
    {
        return (@" 
                                       ███ 
                                     ██   █
                                    █████
                                   █████████
                                  ████████████
                                 ███ ███ ███████
                                ██████████████████
                                 █████████████████
                                  ███████████████
            ");
    }
}
public class Wolf : EnemyBase
{
    public Wolf() : base("늑대(?)", 120)
    {
        Attack = 100;
        Defence = 2;
        Exp = 40;

        DropTable = new()
        {
            { 111,10 }, //포션
            { 116,10 },

            { 002,5 }, //무기
            { 006,5 },

            { 012,5 }, //방어구
        };
    }

    public override string Image()
    {
        return (@" 
                                    /\_____/\
                                   /  o   o  \
                                  ( ==  ^  == )
                                   )         (
                                  (           )
                                   ( (  ^  ) )
                                    (__(__)_)
            ");
    }
}

public class Goblin : EnemyBase
{
    public Goblin() : base("고블린", 200)
    {
        Attack = 80;
        Defence = 8;
        Exp = 50;

        DropTable = new()
        {
            { 111,10 }, //포션
            { 116,10 },

            { 002,5 }, //무기
            { 006,5 },

            { 012,5 }, //방어구
        };
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
//---------------------------------------------------------
public class Golem : EnemyBase
{
    public Golem() : base("골렘", 400)
    {
        Attack = 120;
        Defence = 20;
        Exp = 100;

        DropTable = new()
        {
            { 111,5 }, //포션
            { 112,10 },
            { 116,5 },
            { 117,10 },

            { 002,10 }, //무기
            { 003,5 },
            { 006,10 },
            { 007,5 },

            { 012,10 }, //방어구
            { 013,5 },
        };
    }
    public override string Image()
    {
        return (@" 
                                              ███████
                                            ███▓▓▓███
                                           ██▓████▓██
                                          ██▓██████▓██
                                          ██▓██████▓██
                                          ██▓██████▓██
                                          ████████████
                                           ▐██▌  ▐██▌
                                           ▐██▌  ▐██▌                      
            ");
    }
}

public class BigBug : EnemyBase
{
    public BigBug() : base("거대벌레", 300)
    {
        Attack = 150;
        Defence = 13;
        Exp = 80;

        DropTable = new()
        {
            { 111,5 }, //포션
            { 112,10 },
            { 116,5 },
            { 117,10 },

            { 002,10 }, //무기
            { 003,5 },
            { 006,10 },
            { 007,5 },

            { 012,10 }, //방어구
            { 013,5 },
        };
    }
    public override string Image()
    {
        return (@" 
                                       \/     \/
                                        \_____/
                                       /  o o  \
                                      (    -    )
                                       \_______/
                                       /| | | | \                    
            ");
    }
}

//---------------------------------------------------------

public class Mummy : EnemyBase
{
    public Mummy() : base("미이라", 500)
    {
        Attack = 170;
        Defence = 30;
        Exp = 200;

        DropTable = new()
        {
            { 112,10 }, //포션
            { 113,10 },
            { 117,10 },
            { 118,10 },

            { 003,10 }, //무기
            { 004,5 },
            { 007,10 },
            { 008,5 },

            { 013,10 }, //방어구
            { 014,5 },
        };
    }
    public override string Image()
    {
        return (@" 
                                       [XXXXXX]
                                       [oo  oo]
                                      /[______]\
                                      ||  ||  ||
                                      \[______]/
                                       |      |
                                       |______|
                                       |_|  |_|                    
            ");
    }
}


public class Skeleton : EnemyBase
{
    public Skeleton() : base("스켈레톤", 450)
    {
        Attack = 200;
        Defence = 20;
        Exp = 200;

        DropTable = new()
        {
            { 112,10 }, //포션
            { 113,10 },
            { 117,10 },
            { 118,10 },

            { 003,10 }, //무기
            { 004,5 },
            { 007,10 },
            { 008,5 },

            { 013,10 }, //방어구
            { 014,5 },
        };
    }
    public override string Image()
    {
        return (@" 
                                           .-.
                                          (o o)
                                           |=|
                                          __|__
                                        //.=|=.\\
                                       // .=|=. \\
                                       \\ .=|=. //
                                        \\(_=_)//
                                          /   \
                                         ^^   ^^                     
            ");
    }
}

//---------------------------------------------------------

public class Knight : EnemyBase
{
    public Knight() : base("나이트", 700)
    {
        Attack = 250;
        Defence = 50;
        Exp = 400;

        DropTable = new()
        {
            { 113,15 }, //포션
            { 118,15 },

            { 004,15 }, //무기
            { 008,15 },

            { 014,15 }, //방어구

            { 999,15 }, //보스티켓
        };
    }
    public override string Image()
    {
        return (@" 
                                            ▲
                                           ▓█▓
                                          ▓████▓
                                         ███▀▀███
                                         ██╔══╗██
                                         ██║██║██
                                        ▄██║██║██▄
                                       ████████████
                                          ║████║
                                         ▐█╝  ╚█▌                     
            ");
    }
}

public class Guardian : EnemyBase
{
    public Guardian() : base("가디언", 700)
    {
        Attack = 300;
        Defence = 30;
        Exp = 400;

        DropTable = new()
        {
            { 113,15 }, //포션
            { 118,15 },

            { 004,15 }, //무기
            { 008,15 },

            { 014,15 }, //방어구

            { 999,15 }, //보스티켓
        };
    }
    public override string Image()
    {
        return (@" 
                                          _______
                                         /|     |\
                                        | | [O] | |
                                        | |_____| |
                                        |/[_____]\|
                                         |  /|\  |
                                         |_/ | \_|                    
            ");
    }
}

//---------------------------------------------------------

public class Boss : EnemyBase
{
    public Boss() : base("마왕", 1200)
    {
        Attack = 350;
        Defence = 70;
        Exp = 9999;

        DropTable = new()
        {
            { 113,15 }, //포션
            { 118,15 },

            { 004,15 }, //무기
            { 008,15 },

            { 014,15 }, //방어구
        };
    }
    public override string Image()
    {
        return (@" 
                                          /\     /\
                                         /  \___/  \
                                        |  /[_ _]\  |
                                        |-[_  o  _]-|
                                        |  \[---]/  |
                                         \  /   \  /
                                          \/_____\/                   
            ");
    }

    public override void Die()
    {
        GameManager.Instance.ChangeScene(SceneKey.ClearScene);
        
        base.Die();
    }
}