using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleGameFramework.Player;

public class VitalStats
{
    public int MaxHp { get; private set; }
    public int MaxMp { get; private set; }
    public int Hp { get; private set; }
    public int Mp { get; private set; }
    public bool IsAlive => Hp > 0;

    public VitalStats(int maxHp,int maxMp)
    {
        MaxHp = maxHp;
        Hp = MaxHp;
        MaxMp = maxMp;
        Mp = MaxMp;
    }

    public void ChangeHp(int amount)
    {
        Hp = Math.Clamp(Hp + amount, 0, MaxHp);
    }

    public void ChangeMp(int amount)
    {
        Mp = Math.Clamp(Mp + amount, 0, MaxMp);
    }

    public void AdjustStatus(int maxHpIncreament,int maxMpIncreament)
    {
        MaxHp += maxHpIncreament;
        Hp = MaxHp;
        MaxMp += maxMpIncreament;
        Mp = MaxMp;
    }
 
}

