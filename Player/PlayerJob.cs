using ConsoleGameFramework.Player;
using ConsoleGameProject.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Player;

// 아래는 직업 별 클래스

public class Warrior : PlayerBase
{
    public Warrior() : base(300, 50, 50, 10)
    {
        JobName = "전사";

        SkillList = new List<SkillBase>()
        {
            new HeavyAttack(this),
            new FinalAttack(this),
        };

    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    protected override void LevelUp()
    {
        VitalStats.AdjustStatus(50, 10);
        CombatStats.AdjustStatus(10, 5);

        base.LevelUp();
    }
}

public class Mage : PlayerBase
{
    public Mage() : base(200, 100, 20, 7)
    {
        JobName = "마법사";

        SkillList = new List<SkillBase>()
        {
            new FireBall(this),
            new IceSpear(this),
            new Explosion(this),
            new Heal(this),
        };

    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    protected override void LevelUp()
    {
        VitalStats.AdjustStatus(40, 20);
        CombatStats.AdjustStatus(7, 3);

        base.LevelUp();
    }
}

