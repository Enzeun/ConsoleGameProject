using ConsoleGameFramework.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Item;

public abstract class ItemBase
{
    public readonly int Id;
    public readonly string? Name;
    public string Description { get; protected set; } = "설명이 비어있습니다";

    public ItemBase(int id, string name)
    {
        Id = id;
        Name = name;
    }

}

public abstract class Weapon : ItemBase
{
    public string CompatibleJob { get; protected set; } = "전사";
    public int Attack { get; protected set; } = 0;
    public Weapon(int id, string name) : base(id, name)
    {

    }
}
public abstract class Armor : ItemBase
{
    public int Defence { get; protected set; } = 0;
    public Armor(int id, string name) : base(id, name)
    {

    }
}
public abstract class UsableItem : ItemBase
{
    public UsableItem(int id, string name) : base(id, name)
    {

    }

    public abstract void Use(PlayerBase player);
}

/// <summary>
/// 아이템 데이터베이스 
/// </summary>
public static class ItemData
{
    //public static ItemData Instance { get; } = new ItemData();

    public static readonly Dictionary<int, ItemBase> Data = new()
        {
            {001, new RustedSword()},
            {002, new Sword()},
            {003, new IronSword()},
            {004, new HollySword()},
            {005, new RotenStaff()},
            {006, new WoodStaff()},
            {007, new Staff()},
            {008, new GreatStaff()},
            {011, new GrassArmor()},
            {012, new RotenArmor()},
            {013, new IronArmor()},
            {014, new ChainArmor()},
            {111,new SmallHpPotion() },
            {112,new HpPotion() },
            {113,new BigHpPotion() },
            {116,new SmallMpPotion()  },
            {117,new MpPotion()  },
            {118,new BigMpPotion()  },
            {999,new BossTicket()  },
        };

}