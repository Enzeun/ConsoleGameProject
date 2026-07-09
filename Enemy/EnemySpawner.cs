using ConsoleGameFramework.Core;
using ConsoleGameProject.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Enemy;


/// <summary>
/// 게임에 하나만 있으면 되므로 싱글톤 사용
/// </summary>
public class EnemySpawner
{
    public static EnemySpawner Instance {  get; } = new EnemySpawner();

    // 각 맵의 몬스터 타입을 저장하는 Dictionary
    public readonly Dictionary<MapKey,List<EnemyKey>> EnemiesInMap = new Dictionary<MapKey, List<EnemyKey>>();

    private EnemySpawner()
    {
        RegisterMonsters();
    }

    private void RegisterMonsters()
    {
        EnemiesInMap[MapKey.GrassField] = new List<EnemyKey>()
        {
            EnemyKey.Slime,
            EnemyKey.Goblin,
            EnemyKey.Wolf
        };
        EnemiesInMap[MapKey.Forest] = new List<EnemyKey>()
        {
            EnemyKey.Goblin,
            EnemyKey.Golem,
            EnemyKey.BigBug,
        };
        EnemiesInMap[MapKey.Cave] = new List<EnemyKey>()
        {
            EnemyKey.Golem,
            EnemyKey.Mummy,
            EnemyKey.Skeleton,

        };
        EnemiesInMap[MapKey.Castle] = new List<EnemyKey>()
        {
            EnemyKey.Skeleton,
            EnemyKey.Knight,
            EnemyKey.Guardian,

        };
        EnemiesInMap[MapKey.BossMap] = new List<EnemyKey>()
        {
            EnemyKey.Boss,

        };
        EnemiesInMap[MapKey.Dummy] = new List<EnemyKey>()
        {
            EnemyKey.Boss,

        };
    }

    public EnemyBase SpawnRandomEnemy()
    {
        MapKey currentMap = GameManager.Instance.CurrentMap.Key;

        int randomInt = GameManager.Instance.Context.Random.Next(0, EnemiesInMap[currentMap].Count);

        EnemyKey randomKey = EnemiesInMap[currentMap][randomInt];

        switch (randomKey)
        {
            case EnemyKey.Slime:
                return new Slime();
            case EnemyKey.Wolf:
                return new Wolf();
            case EnemyKey.Goblin:
                return new Goblin();
            case EnemyKey.Golem:
                return new Golem();
            case EnemyKey.BigBug:
                return new BigBug();
            case EnemyKey.Mummy:
                return new Mummy();
            case EnemyKey.Skeleton:
                return new Skeleton();
            case EnemyKey.Knight:
                return new Knight();
            case EnemyKey.Guardian:
                return new Guardian();
            case EnemyKey.Boss:
                return new Boss();



        }

        throw new InvalidOperationException();
    }
}
