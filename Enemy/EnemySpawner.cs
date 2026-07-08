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
    public static Dictionary<int,List<Type>> EnemysInMap = new Dictionary<int,List<Type>>(5);

    private EnemySpawner()
    {

    }

    private void RegisterMonsters()
    {
        EnemysInMap[1] = new List<Type>()
        {
            typeof(Slime),
            typeof(Wolf),
            typeof(Goblin),
        };
    }


}
