using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Player;



public abstract class Player : IDamageable
{
    public VitalStats VitalStats { get; private set; }

    public int CurrentHp => VitalStats.Hp;
    public int MaxHp => VitalStats.MaxHp;
    public bool IsAlive => VitalStats.IsAlive;

    private bool _isDead = false;
    // --------------------------------------------------------

    public CombatStats CombatStats { get; private set; }



    public Player(int maxHp, int maxMp, int attack, int defence)
    {

        VitalStats = new VitalStats(maxHp, maxMp);
        CombatStats = new CombatStats(attack, defence);
    }

    // 공격력 가져오기
    public int FinalAttack => CombatStats.BaseAttack; 


    // 데미지 계산
    public virtual void TakeDamage(int damage)
    {
        // 죽으면 스킵
        if (_isDead) return;
        // 이전 체력 기록 (방송 용)
        int prevHp = VitalStats.Hp;
        // 체력 변경
        VitalStats.ChangeHp(-damage);
        // 이벤트 방송 (스탯 전달)
        if (prevHp != VitalStats.Hp)
            OnHpChanged?.Invoke(VitalStats);
        // 체력이 0 이면 죽음 확인 (Clamp 때문에 죽는 체력은 0 으로 고정)
        if (VitalStats.Hp == 0 && !_isDead)
        {
            Die();
        }
    }

    // 죽는 이벤트 여기서 처리
    protected virtual void Die()
    {
        _isDead = true;
        OnDied?.Invoke();
    }

    // 플레이어 죽음
    public event Action? OnDied;
    // 체력이 변경될 때. 
    public event Action<VitalStats>? OnHpChanged;

}

public class Worrior : Player
{
    public Worrior() : base(150, 50, 50, 10)
    {

    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

}

