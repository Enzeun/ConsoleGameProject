using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameProject.Enemy;

namespace ConsoleGameProject.Scenes;

internal class BattleScene : SceneBase
{
    public override SceneKey Key => SceneKey.BattleScene;

    private bool hasWin = false;

    public EnemyBase Enemy;

    /// <summary>
    /// 하단의 메뉴를 결정하는 변수
    /// </summary>
    int menuHandler = 1;


    public override void Enter(GameContext context)
    {
        context.AddLog("배틀화면 진입");
        context.Random.Next(0, 3);
        Enemy = new EnemyBase("슬라임", 100);
        menuHandler = 1; // 초기화
    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"전투 시작!!", "몬스터와 조우했습니다!");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------

        // ---------------------------몬스터 정보---------------------------------------------------------
        ConsoleUI.Write("                              ");
        ConsoleUI.WriteLine("  .----.");
        ConsoleUI.Write("                              ");
        if (Enemy.IsAlive)
        {
            ConsoleUI.WriteLine("  (O  O)");
        }
        else
            ConsoleUI.WriteLine("  (X  X)");
        ConsoleUI.Write("                              ");
        ConsoleUI.WriteLine("  / ()  |");
        ConsoleUI.Write("                              ");
        ConsoleUI.WriteLine(" /   /|  |");
        ConsoleUI.Write("                              ");
        ConsoleUI.WriteLine("|___| |___|");

        ConsoleUI.WriteLine();


        // 몬스터 이름 : HP 바
        ConsoleUI.WriteStatusBar($"{Enemy.Name}", Enemy.Hp, Enemy.MaxHp, 24, ConsoleColor.DarkRed);

        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();

        ConsoleUI.WriteLine("  .----. ");
        ConsoleUI.WriteLine("  |   -| ");
        ConsoleUI.WriteLine("  '----'  ");
        ConsoleUI.WriteLine("  /   |  ");


        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteKeyValue($"[{GameManager.Instance.Player.JobName}]", $"[{GameManager.Instance.Player.Name}]", 10);
        ConsoleUI.WriteStatusBar("HP", GameManager.Instance.Player.CurrentHp, GameManager.Instance.Player.MaxHp);


        // ---------------------------로그---------------------------------------------------------
        ConsoleUI.WriteLog(context.Logs);
    }
    //기본메뉴
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "기본 공격"),
        new MenuOption(2, "스킬 사용"),
        new MenuOption(3, "인벤토리 열기"),                

        //new MenuOption(9, "레벨업."), // 디버깅용
        //new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
        //new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    //스킬 메뉴
    private static readonly List<MenuOption> SkillMenu = new List<MenuOption>
    {
        new MenuOption(1, "1번스킬"),
        new MenuOption(2, "2번스킬"),

    };

    //인벤토리 메뉴
    private static readonly List<MenuOption> InventoryMenu = new List<MenuOption>
    {
        new MenuOption(1, "기본 공격"),
        new MenuOption(2, "스킬 사용"),
        new MenuOption(3, "인벤토리 열기"),                

    };


    public override void HandleInput(GameContext context)
    {
        switch (menuHandler)
        {

            // ---------------------------기본 메뉴---------------------------------------------------------
            case 1:
                ConsoleUI.WriteMenu(Menu, "행동 선택");
                int choice = ConsoleUI.ReadMenuChoice(Menu);

                switch (choice)
                {
                    case 1: // 기본공격
                        context.AddLog("기본공격을 합니다"); // 디버깅
                        Enemy.TakeDamege(GameManager.Instance.Player.FinalAttack);
                        break;

                    case 2: // 스킬 사용                    
                        context.AddLog("스킬 메뉴를 엽니다"); // 디버깅
                        menuHandler = 2;
                        break;
                }
                break; 
            case 2:
                ConsoleUI.WriteMenu(SkillMenu, "행동 선택");
                choice = ConsoleUI.ReadMenuChoice(Menu);
                break;




                // ---------------------------스킬 메뉴---------------------------------------------------------
                // ---------------------------인벤토리 메뉴---------------------------------------------------------





        }





    }
}
