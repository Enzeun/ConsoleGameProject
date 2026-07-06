using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Player;


public interface IDamageable
{
    int CurrentHp { get; } 
    int MaxHp { get; }
    bool IsAlive { get; }
    float HpPercentage => (float)CurrentHp / MaxHp;

    void TakeDamage(int damage);
}
