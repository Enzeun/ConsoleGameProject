using ConsoleGameFramework.Core;
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

    /// <summary>
    /// 몬스터가 주는 경험치
    /// </summary>
    public int Exp { get; protected set; } = 10;

    /// <summary>
    /// 몬스터가 드롭하는 아이템 : 아이템키, 드롭률
    /// </summary>
    public Dictionary<int, int> DropTable { get; protected set; } = new()
    {
        { 111,30 },
        { 116,30 }
    };

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
    /// 랜덤 아이템 Key를 반환합니다. (드롭테이블에 존재하는 것만) / -1 : 아이템이 없는 경우 에러가 날 수 있으니 처리할 것
    /// </summary>
    /// <returns></returns>
    public virtual int DropRandomItem()
    {
        int randomInt = GameManager.Instance.Context.Random.Next(0, 100);

        int CurrentCount = 0;

        foreach (var item in DropTable)
        {
                Console.WriteLine($"랜덤값 : {randomInt}   /   현재값 : {CurrentCount}");
            if (item.Value + CurrentCount >= randomInt)
            {                
                Console.WriteLine($"{item.Value}");
                return item.Key;
            } 
            else
            {
                CurrentCount = CurrentCount + item.Value;
            }
        }
        return -1;

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


