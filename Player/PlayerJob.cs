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
        // 기본무기 추가
        AddEquimentItem(001);

        // 기본방어구 추가
        AddEquimentItem(011);

        // 기본 아이템 추가 (HP 포션 2개, Mp 포션 1개)
        AddConsumableItem(111);
        AddConsumableItem(111);
        AddConsumableItem(116);

        // 기본장비 장착
        EquipItem(001);
        EquipItem(011);
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
                


        // 기본무기 추가
        AddEquimentItem(001);

        // 기본방어구 추가
        AddEquimentItem(011);

        // 기본 아이템 추가 (HP 포션 2개, Mp 포션 1개)
        AddConsumableItem(111);
        AddConsumableItem(111);
        AddConsumableItem(116);

        // 기본장비 장착
        EquipItem(001);
        EquipItem(011);
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
