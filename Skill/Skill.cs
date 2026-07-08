using ConsoleGameFramework.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Skill;

// 마법사 스킬----------------------------------------------------------
public class FireBall : SkillBase
{
    
    public FireBall(PlayerBase player) : base(player)
    {
        Name = "파이어 볼";
        Description = "불덩이를 적에게 날립니다";

        ConsumeMp = 10;

        AddDamage = 0;

        DamageMultiplier = 2;
    }
}
public class IceSpear : SkillBase
{
    
    public IceSpear(PlayerBase player) : base(player)
    {
        Name = "아이스 스피어";
        Description = "얼음 창을 만들어 적에게 날립니다";

        ConsumeMp = 10;

        AddDamage = 50;

        DamageMultiplier = 1;
    }
}
public class Explosion : SkillBase
{
    
    public Explosion(PlayerBase player) : base(player)
    {
        Name = "대폭발";
        Description = "적의 위치에 큰 폭발을 일으킵니다";

        ConsumeMp = 50;

        AddDamage = 100;

        DamageMultiplier = 3;
    }
}
public class Heal : SkillBase
{
    int healamount = 100;
    public Heal(PlayerBase player) : base(player)
    {
        Name = "힐";
        Description = "체력을 회복합니다";

        ConsumeMp = 10;

        AddDamage = 0;

        DamageMultiplier = 1;
    }
    
    public override void UseSkill(IDamageable target)
    {        
        Caster.Heal(healamount);
    }
}


// 전사 스킬----------------------------------------------------------
public class HeavyAttack : SkillBase
{
    
    public HeavyAttack(PlayerBase player) : base(player)
    {
        Name = "무거운 일격";
        Description = "힘을 모아 강하게 때립니다";

        ConsumeMp = 10;

        AddDamage = 0;

        DamageMultiplier = 2;
    }
}

public class FinalAttack : SkillBase
{
    
    public FinalAttack(PlayerBase player) : base(player)
    {
        Name = "최후의 일격";
        Description = "젖 먹던 힘까지 모아 강하게 때립니다";

        ConsumeMp = 50;

        AddDamage = 0;

        DamageMultiplier = 3;
    }
}
