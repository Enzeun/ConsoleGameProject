using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Item;


//---------------------무기--------------------------------------------------------------

public class Sword : ItemBase, IEquipable
{

    public Sword() : base(001, "강철 검")
    {
    }

    public void Equip()
    {

    }
}




//---------------------방어구--------------------------------------------------------------
public class Armor : ItemBase, IEquipable
{
    public Armor() : base(011, "철 갑옷")
    {

    }
    public void Equip()
    {

    }
}





//---------------------포션--------------------------------------------------------------

public class HpPotion : ItemBase, IConsumable
{
    public HpPotion() : base(111, "HP 포션")
    {

    }
    public void Use()
    {

    }
}

public class MpPotion : ItemBase, IConsumable
{
    public MpPotion() : base(112, "MP 포션")
    {

    }
    public void Use()
    {

    }
}

// 버프포션 시간남으면 추가하자



//---------------------기타--------------------------------------------------------------
public class BossTicket : ItemBase
{
    public BossTicket() : base(999, "보스 티켓")
    {

    }
    public void Use()
    {

    }
}



