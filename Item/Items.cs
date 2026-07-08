using ConsoleGameFramework.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Item;


//---------------------무기--------------------------------------------------------------

public class RustedSword : Weapon, IEquipable
{

    public RustedSword() : base(001, "녹슨 검")
    {
        Attack = 10;
    }

}

public class Sword : Weapon, IEquipable
{

    public Sword() : base(002, "일반 검")
    {
        Attack = 20;
    }

}
public class IronSword : Weapon, IEquipable
{

    public IronSword() : base(003, "강철 검")
    {
        Attack = 40;
    }

}
public class HollySword : Weapon, IEquipable
{

    public HollySword() : base(004, "성검")
    {
        Attack = 80;
    }

}
public class RotenStaff : Weapon, IEquipable
{

    public RotenStaff() : base(005, "조잡한 지팡이")
    {
        Attack = 10;
        CompatibleJob = "마법사";
    }

}
public class WoodStaff : Weapon, IEquipable
{

    public WoodStaff() : base(006, "나무 지팡이")
    {
        Attack = 20;
    }

}
public class Staff : Weapon, IEquipable
{

    public Staff() : base(007, "좋은 지팡이")
    {
        Attack = 40;
    }

}
public class GreatStaff : Weapon, IEquipable
{

    public GreatStaff() : base(008, "마도사의 지팡이")
    {
        Attack = 80;
    }

}

//---------------------방어구--------------------------------------------------------------
public class GrassArmor : Armor, IEquipable
{
    public GrassArmor() : base(011, "거적떼기")
    {
        Defence = 5;
    }
}
public class RotenArmor : Armor, IEquipable
{
    public RotenArmor() : base(012, "녹슨 갑옷")
    {
        Defence = 10;
    }
    
}
public class IronArmor : Armor, IEquipable
{
    public IronArmor() : base(013, "철 갑옷")
    {
        Defence = 20;
    }
 
}
public class ChainArmor : Armor, IEquipable
{
    public ChainArmor() : base(014, "체인 갑옷")
    {
        Defence = 30;
    }
   
}





//---------------------포션--------------------------------------------------------------

public class SmallHpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 100;
    public SmallHpPotion() : base(111, "작은 HP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryHp(RecoverAmount);
    }
}
public class HpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 200;
    public HpPotion() : base(112, "중간 HP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryHp(RecoverAmount);
    }
}
public class BigHpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 300;
    public BigHpPotion() : base(113, "큰 HP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryHp(RecoverAmount);
    }
}

public class SmallMpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 100;

    public SmallMpPotion() : base(116, "작은 MP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryMp(RecoverAmount);
    }
}
public class MpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 200;

    public MpPotion() : base(117, "중간 MP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryMp(RecoverAmount);
    }
}
public class BigMpPotion : UsableItem, IConsumable
{
    public int RecoverAmount { get; private set; } = 300;

    public BigMpPotion() : base(118, "큰 MP 포션")
    {

    }
    public override void Use(PlayerBase player)
    {
        player.RecoveryMp(RecoverAmount);
    }
}

// 버프포션 시간남으면 추가하자



//---------------------기타--------------------------------------------------------------
public class BossTicket : UsableItem
{
    public BossTicket() : base(999, "보스 티켓")
    {

    }
    public override void Use(PlayerBase player)
    {

    }
}



