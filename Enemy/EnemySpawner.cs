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
    public readonly Dictionary<MapKey,List<Type>> EnemiesInMap = new Dictionary<MapKey, List<Type>>(5);

    private EnemySpawner()
    {
        RegisterMonsters();
    }

    private void RegisterMonsters()
    {
        EnemiesInMap[MapKey.GrassField] = new List<Type>()
        {
            typeof(Slime),
            typeof(Wolf),
            typeof(Goblin),
        };
        EnemiesInMap[MapKey.Forest] = new List<Type>()
        {

        };
        EnemiesInMap[MapKey.Cave] = new List<Type>()
        {

        };
        EnemiesInMap[MapKey.Castle] = new List<Type>()
        {

        };
        EnemiesInMap[MapKey.Dummy] = new List<Type>()
        {

        };
    }
}
