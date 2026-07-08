using ConsoleGameFramework.Core;
using ConsoleGameProject.Item;
using ConsoleGameProject.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Player;


public abstract class PlayerBase : IDamageable, ISkillCaster
{

    // 기본 필드
    public string Name { get; set; }
    public VitalStats VitalStats { get; private set; }

    public int CurrentHp => VitalStats.Hp;
    public int CurrentMp => VitalStats.Mp;
    public int MaxHp => VitalStats.MaxHp;
    public int MaxMp => VitalStats.MaxMp;
    public bool IsAlive => VitalStats.IsAlive;

    private bool _isDead = false;
    // --------------------------------------------------------
    public string JobName { get; protected set; }


    // --------------------------------------------------------
    // 기본값이 있는 필드들 
    private int _maxLevel = 10;

    private int _level = 1;
    public int Level
    {
        get => _level;
    }

    private int[] _maxExpOfLevel =
    {
        100,150,225,325,450,600,750,925,1125,1500,999999
    };

    private int _currentExp = 0;
    public int CurrentExp { get => _currentExp; }
    public int LevelUpExp { get => _maxExpOfLevel[Level - 1]; }
    public bool IsmaxLevel { get => _level == _maxLevel; }

    // --------------------------------------------------------

    public CombatStats CombatStats { get; private set; }

    // --------------------------------------------------------

    // 생성자
    public PlayerBase(int maxHp = 100, int maxMp = 50, int attack = 10, int defence = 10)
    {

        VitalStats = new VitalStats(maxHp, maxMp);
        CombatStats = new CombatStats(attack, defence);
    }

    /// <summary>
    /// 최종 공격력 (기본 공격력 + 장비 공격력)
    /// </summary>
    public int FinalAttack => CombatStats.BaseAttack;

    /// <summary>
    /// 최종 방어력 (기본 방어력 + 장비 방어력)
    /// </summary>
    public int FinalDefence => CombatStats.BaseDefence;

    /// <summary>
    /// 데미지 계산
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(int damage)
    {
        // 죽으면 스킵
        if (_isDead) return;
        // 이전 체력 기록 (방송 용)
        int prevHp = VitalStats.Hp;
        // 데미지 계산
        int newDamage = Math.Max(damage - FinalDefence, 1);
        // 체력 변경
        VitalStats.ChangeHp(-newDamage);
        // 이벤트 방송 (스탯 전달)
        if (prevHp != VitalStats.Hp)
            OnHpChanged?.Invoke(VitalStats);
        // 체력이 0 이면 죽음 확인 (Clamp 때문에 죽는 체력은 0 으로 고정)
        if (VitalStats.Hp == 0 && !_isDead)
        {
            Die();
        }
    }

    /// <summary>
    /// 죽는 이벤트 여기서 처리
    /// </summary>
    protected virtual void Die()
    {
        _isDead = true;
        OnDied?.Invoke();

        GameManager.Instance.RequestQuit();
    }

    /// <summary>
    /// 경험치 얻는 함수
    /// </summary>
    /// <param name="expGain"></param>
    public virtual void GainExp(int expGain)
    {
        // 만렙이면 경험치 X
        if (_level == 10)
        {
            GameManager.Instance.Context.AddLog($"더 이상 경험치를 얻을 수 없습니다"); // 디버깅
            return;

        }

        _currentExp = _currentExp + expGain;

        if (_currentExp >= _maxExpOfLevel[_level - 1])
        {
            _currentExp -= _maxExpOfLevel[_level - 1];

            LevelUp();
        }

        GameManager.Instance.Context.AddLog($"경험치를 {expGain} 얻었습니다"); // 디버깅

        OnGainExp?.Invoke();
    }

    /// <summary>
    /// 레벨 업
    /// </summary>
    protected virtual void LevelUp()
    {
        _level++;

        if (_level == 10)
        {
            _currentExp = _maxExpOfLevel[_level - 1];
        }

        GameManager.Instance.Context.AddLog("레벨업 했습니다"); // 디버깅
        OnLevelUp?.Invoke();
    }

    /// <summary>
    /// 플레이어 체력 회복
    /// </summary>
    /// <param name="amount"></param>
    public virtual void RecoveryHp(int amount)
    {
        VitalStats.ChangeHp(amount);
    }

    public virtual void UseMp(int amount)
    {
        VitalStats.ChangeMp(-amount);
    }

    public virtual void RecoveryMp(int amount)
    {
        VitalStats.ChangeMp(amount);
    }

    // 플레이어 죽음
    public event Action? OnDied;
    // 체력이 변경될 때. 
    public event Action<VitalStats>? OnHpChanged;

    // 경험치 얻을 때
    public event Action? OnGainExp;
    // 레벨업 했을 때
    public event Action? OnLevelUp;

    //--------------------스킬---------------------------------------------------------------------------

    public List<SkillBase> SkillList { get; protected set; }


    public virtual void UseSkill(SkillBase skill, IDamageable target)
    {
        if (skill == null)
            return;
        else
        {
            skill.UseSkill(target);
        }
    }

    //--------------------장비 인벤토리---------------------------------------------------------------------------

    public List<ItemBase> EquipmentInventory { get; protected set; }

    public bool AddEquimentItem(ItemBase item)
    {
        if (EquipmentInventory.Contains(item))
            return false;
        else
        {
            EquipmentInventory.Add(item);
            return true;
        }
    }

    //--------------------아이템 인벤토리---------------------------------------------------------------------------
    /// <summary>
    /// 소비아이템 Dic<아이템id, 갯수>
    /// </summary>
    public Dictionary<int, int> ConsumableInventory { get; protected set; }

    public void AddConsumableItem(ItemBase item)
    {
        if (ConsumableInventory.ContainsKey(item.Id))
        {
            ConsumableInventory[item.Id] += 1;
        }

        ConsumableInventory.Add(item.Id, 1);
    }


}