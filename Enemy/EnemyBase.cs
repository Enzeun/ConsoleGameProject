using ConsoleGameFramework.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;

public class EnemyBase : IDamageable
{
    public string Name { get; protected set; }
    public int MaxHp { get; protected set; }
    private int _hp;
    public int CurrentHp
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHp);
    }
    public int Attack { get; protected set; } = 10;
    public int Defence { get; protected set; } = 5;
    public bool IsAlive => _hp > 0;
    private bool _isDead = false;

    public int Exp { get; protected set; } = 10;

    /// <summary>
    /// 생성자 필드 : 이름,최대체력,공격력,방어력
    /// </summary>
    /// 이름<param name="name">이름</param>
    /// <param name="maxHp">최대체력</param>
    /// <param name="attakc">공격력</param>
    /// <param name="defence">방어력</param>
    public EnemyBase(string name, int maxHp)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = MaxHp;

    }

    public virtual void TakeDamage(int damage)
    {
        // 죽으면 스킵
        if (_isDead)
            return;
        // 데미지 계산
        int newDamage = Math.Max(damage - Defence, 1);
        CurrentHp -= newDamage;
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
        OnDied?.Invoke(Exp);
    }

    /// <summary>
    /// 죽었을 때 이벤트 / 반환값 : 경험치, 랜덤아이템
    /// </summary>
    public event Action<int> OnDied;

    // 몬스터 이미지
    public virtual string Image()
    {
        return (@"
                                     .----.
                                     (O  O)              
                                     / ()  |
                                    /   /|  |
                                   |___| |___|
        ");

    }


}


