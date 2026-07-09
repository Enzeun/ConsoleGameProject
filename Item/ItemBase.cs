using ConsoleGameFramework.Core;
using ConsoleGameFramework.Player;
using ConsoleGameFramework.UI;
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


    /// <summary>
    /// 플레이어의 소모품 인벤토리를 메뉴로 변환하여 받아오는 함수 / 반환값 : 메뉴, Dict(메뉴번호,아이템Key값)
    /// </summary>
    /// <returns></returns>
    public static (List<MenuOption> menu, Dictionary<int, int> mapping) MakeInventoryMenu()
    {
        PlayerBase Player = GameManager.Instance.Player;
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        List<MenuOption> menu = new List<MenuOption>();

        int count = 1;

        foreach (int key in Player.ConsumableInventory.Keys)
        {
            int itemcount = Player.ConsumableInventory[key];

            string itemName = Data[key].Name;

            string itemDesc = Data[key].Description;

            bool canUse = Player.ConsumableInventory[key] > 0;

            MenuOption menuOption = new MenuOption(count, $"{itemName} X {itemcount} 개", $"{itemDesc}", canUse);

            menu.Add(menuOption);

            mapping[count] = key;

            count++;
        }

        menu.Add(new MenuOption(0, "취소"));

        return (menu, mapping);
    }


    /// <summary>
    /// 플레이어의 장비 인벤토리를 메뉴로 변환하여 받아오는 함수 / 반환값 : 메뉴, Dict(메뉴번호,아이템Key값)
    /// </summary>
    /// <returns></returns>
    public static (List<MenuOption> menu, Dictionary<int, int> mapping) MakeEquipmentMenu()
    {
        PlayerBase Player = GameManager.Instance.Player;
        Dictionary<int, int> mapping = new Dictionary<int, int>();
        List<MenuOption> menu = new List<MenuOption>();

        int count = 1;

        foreach (var item in Player.EquipmentInventory)
        {            
            string itemName = item.Name;

            string itemDesc = "";

            bool canUse = true;

            if (item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                if (Player.EquippedWeapon == weapon)
                {
                    itemDesc = "[장비됨]";
                    canUse = false;
                }         
                else if (Player.JobName != weapon.CompatibleJob)
                {
                    itemDesc = "[장비불가]";
                    canUse = false;
                }
            }
            else if (item is Armor)
            {
                if (Player.EquippedArmor == item)
                {
                    itemDesc = "[장비됨]";
                    canUse = false;
                }
            }

            MenuOption menuOption = new MenuOption(count, $"{itemName}", $"{itemDesc}", canUse);

            menu.Add(menuOption);

            mapping[count] = item.Id;

            count++;
        }

        menu.Add(new MenuOption(0, "취소"));

        return (menu, mapping);
    }

}