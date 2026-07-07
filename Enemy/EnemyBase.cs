using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;

public class EnemyBase
{
    public string Name { get; protected set; }
    public int MaxHp { get; protected set; }
    private int _hp;
    public int Hp
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHp);
    }
    public int Attack { get; protected set; } = 10;
    public int Defence { get; protected set; } = 5;
    public bool IsAlive => _hp > 0;
    private bool _isDead = false;

    public EnemyBase(string name, int maxHp)
    {
        MaxHp = maxHp;
        Hp = MaxHp;

    }

    public virtual void TakeDamage(int damage) 
    { 
        // 죽으면 스킵
        if (_isDead)
            return;
        // 데미지 계산
        int newDamage = damage - Defence;
        Hp -= newDamage;
        // 체력 변경
        // 0이되면 사망처리
        if (_hp == 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        _isDead = true;
        OnDied?.Invoke();
    }

    public event Action OnDied;
}
