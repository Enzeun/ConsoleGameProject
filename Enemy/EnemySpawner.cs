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

        };
        EnemiesInMap[MapKey.Cave] = new List<EnemyKey>()
        {

        };
        EnemiesInMap[MapKey.Castle] = new List<EnemyKey>()
        {

        };
        EnemiesInMap[MapKey.Dummy] = new List<EnemyKey>()
        {

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




        }

        return new Slime();
    }
}
