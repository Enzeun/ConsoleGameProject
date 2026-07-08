using ConsoleGameFramework.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Skill;

public class SkillBase
{
    public PlayerBase Caster { get; private set; }
    public string Name { get; protected set; } = "스킬";
    public string Description { get; protected set; } = "설명";

    public int ConsumeMp { get; protected set; } = 0;
    public int AddDamage { get; protected set; } = 0;
    public int DamageMultiplier { get; protected set; } = 1;

    public SkillBase(PlayerBase player)
    {
        Caster = player;
    }

    public virtual void UseSkill(IDamageable target)
    {
        int finalDamage = Caster.FinalAttack * DamageMultiplier + AddDamage;

        target.TakeDamage(finalDamage);
    }
}
