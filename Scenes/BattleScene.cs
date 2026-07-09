using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGameProject.Enemy;
using ConsoleGameFramework.Player;
using ConsoleGameProject.Skill;
using ConsoleGameProject.Item;

namespace ConsoleGameProject.Scenes;

internal class BattleScene : SceneBase
{
    public override SceneKey Key => SceneKey.BattleScene;

    private bool hasWin = false;

    private PlayerBase Player;

    public EnemyBase Enemy;

    /// <summary>
    /// 하단의 메뉴를 결정하는 변수
    /// </summary>
    int menuHandler = 1;

    private string _infoString = "";

    public override void Enter(GameContext context)
    {
        // 초기화
        menuHandler = 1;
        hasWin = false;

        // 플레이어 객체 등록
        Player = GameManager.Instance.Player;

        // 플레이어 스킬 숫자 만큼 스킬메뉴 추가
        InitializeSkillMenu();

        // 디버깅
        //context.AddLog("배틀화면 진입");    

        // 랜덤 적 생성
        Enemy = EnemySpawner.Instance.SpawnRandomEnemy();

        //Enemy = new Slime(); // 디버깅용 더미 데이터

        // 죽었을때의 이벤트 구독
        Enemy.OnDied += WinBattle;

        _infoString = "적과 조우했습니다!";
    }

    private void WinBattle(int exp)
    {
        hasWin = true;

        Player.GainExp(exp);

        _infoString = "승리했습니다!!";


        // 현재는 배틀이 끝나는 조건이 이겼을 때나, 게임오버 밖에 없기 때문에 여기서 구독해제함.
        Enemy.OnDied -= WinBattle;
    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"전투 시작!!", "몬스터와 조우했습니다!");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------

        // ---------------------------몬스터 정보---------------------------------------------------------
        //ConsoleUI.Write("                              ");
        //ConsoleUI.WriteLine("  .----.");
        //ConsoleUI.Write("                              ");
        //if (Enemy.IsAlive)
        //{
        //    ConsoleUI.WriteLine("  (O  O)");
        //}
        //else
        //    ConsoleUI.WriteLine("  (X  X)");
        //ConsoleUI.Write("                              ");
        //ConsoleUI.WriteLine("  / ()  |");
        //ConsoleUI.Write("                              ");
        //ConsoleUI.WriteLine(" /   /|  |");
        //ConsoleUI.Write("                              ");
        //ConsoleUI.WriteLine("|___| |___|");


        ConsoleUI.WriteLine($"                                        {Enemy.Name}");
        ConsoleUI.WriteLine($"{Enemy.Image()}");

        // 몬스터 이름
        // HP 바
        ConsoleUI.WriteStatusBar($"HP", Enemy.CurrentHp, Enemy.MaxHp, 24, ConsoleColor.DarkRed);
        // --------------------------- (빈칸)  ---------------------------------------------------------

        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();

        // ---------------------------플레이어 이미지---------------------------------------------------------


        ConsoleUI.WriteLine("            .----. ");
        ConsoleUI.WriteLine("            |   -| ");
        ConsoleUI.WriteLine("            '----'  ");
        ConsoleUI.WriteLine("            /   |  ");


        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteKeyValue($"[{Player.JobName}]", $"[{Player.Name}]", 10);
        ConsoleUI.WriteLine($"Lv.{Player.Level}");
        ConsoleUI.WriteStatusBar("HP", Player.CurrentHp, Player.MaxHp);
        ConsoleUI.WriteStatusBar("MP", Player.CurrentMp, Player.MaxMp, 24, ConsoleColor.DarkBlue);
        if (!Player.IsmaxLevel)
        {
            ConsoleUI.WriteStatusBar("EXP", Player.CurrentExp, Player.LevelUpExp, 24, ConsoleColor.DarkYellow);
        }
        else
        {
            ConsoleUI.WriteStatusBar("EXP", 999999, 999999, 24, ConsoleColor.DarkYellow);
        }


        // ---------------------------로그---------------------------------------------------------
        //ConsoleUI.WriteLog(context.Logs);
    }
    //기본메뉴
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "기본 공격"),
        new MenuOption(2, "스킬 사용"),
        //new MenuOption(3, "인벤토리 열기"),                

        //new MenuOption(9, "레벨업."), // 디버깅용
        //new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
        //new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    //스킬 메뉴
    private static readonly List<MenuOption> SkillMenu = new List<MenuOption>
    {
        //new MenuOption(1, "1번스킬"),
        //new MenuOption(2, "2번스킬"),        
        //new MenuOption(0, "취소"),
    };

    /// <summary>
    /// 스킬메뉴를 초기화 (플레이어가 가진 스킬들로 메뉴 구성)
    /// </summary>
    private void InitializeSkillMenu()
    {
        SkillMenu.Clear();
        for (int i = 0; i < Player.SkillList.Count; i++)
        {
            //if (i > 4) // 스킬은 최대 4개 까지만 허용
            //    return;

            bool canUseSkill = true;

            if (Player.CurrentMp < Player.SkillList[i].ConsumeMp)
                canUseSkill = false;

            MenuOption menuOption = new MenuOption(i + 1, Player.SkillList[i].Name, Player.SkillList[i].Description, canUseSkill);

            if (SkillMenu.Contains(menuOption))
                continue;

            SkillMenu.Add(menuOption);
        }
        SkillMenu.Add(new MenuOption(0, "취소"));
    }

    //인벤토리 메뉴
    private static readonly List<MenuOption> InventoryMenu = new List<MenuOption>
    {
        new MenuOption(1, "기본 공격"),
        new MenuOption(2, "스킬 사용"),

        new MenuOption(0, "취소"),

    };

    private bool _isPlayerTurn = true;

    private void NextTurn()
    {
        _isPlayerTurn = !_isPlayerTurn;
        ConsoleUI.WriteMenu(Menu, "행동 선택");

    }

    private void PlayerAttack()
    {
        _infoString = "플레이어가 공격!";

        Enemy.TakeDamage(Player.FinalAttack);

        NextTurn();
    }

    private void EnemyAttack()
    {
        _infoString = "적이 공격했다!";

        Player.TakeDamage(Enemy.Attack);

        NextTurn();
    }

    private void PlayerUseSkill(int num)
    {
        int index = num - 1;
        _infoString = $"{Player.SkillList[index].Name} 스킬을 사용!";

        Player.SkillList[index].UseSkill(Enemy);

        NextTurn();

    }


    public override void HandleInput(GameContext context)
    {
        ConsoleUI.WriteRule();
        ConsoleUI.WriteCentered(_infoString);
        ConsoleUI.WriteRule();

        if (hasWin)
        {
            if (Enemy is Boss)
            {
                GoTo(context, SceneKey.ClearScene);
            }

            // 아이템 드롭 처리
            int drop = Enemy.DropRandomItem();

            if (drop != -1)
            {
                string name = ItemData.Data[drop].Name;
                switch (Player.AddEquimentItem(drop))
                {
                    case 1:
                        ConsoleUI.ReadString($"'{name}'을 얻었습니다.", "엔터를 눌러 계속");
                        break;
                    case -1:
                        ConsoleUI.WriteToast("없는 아이템입니다. 코딩이 잘못됐습니다", ToastType.Error);
                        break;
                    case -2:
                        ConsoleUI.WriteToast("이미 있는 아이템입니다. 작은 HP 포션으로 전환합니다", ToastType.Info);
                        Player.AddConsumableItem(111);
                        break;
                    case -3:
                        Player.AddConsumableItem(drop);
                        ConsoleUI.ReadString($"'{name}'을 얻었습니다.", "엔터를 눌러 계속");
                        break;
                }
            }

            GoTo(context, SceneKey.Map);
        }

        if (_isPlayerTurn)
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
                            PlayerAttack();
                            break;

                        case 2: // 스킬창 열기                    
                            context.AddLog("스킬 메뉴를 엽니다"); // 디버깅
                            menuHandler = 2;
                            break;

                        case 3: // 인벤토리 열기                    
                            context.AddLog("인벤토리를 엽니다"); // 디버깅
                            menuHandler = 3;
                            break;
                    }
                    break;
                // ---------------------------스킬 메뉴---------------------------------------------------------
                case 2:
                    ConsoleUI.WriteMenu(SkillMenu, "행동 선택");
                    choice = ConsoleUI.ReadMenuChoice(SkillMenu);

                    switch (choice)
                    {
                        case 1: // 1번 스킬                            
                            context.AddLog("1번 스킬을 사용합니다"); // 디버깅
                            PlayerUseSkill(1);
                            menuHandler = 1;
                            break;
                        case 2: // 2번 스킬                    
                            context.AddLog("2번 스킬을 사용합니다"); // 디버깅
                            PlayerUseSkill(2);
                            menuHandler = 1;
                            break;
                        case 3: // 3번 스킬                    
                            context.AddLog("3번 스킬을 사용합니다"); // 디버깅
                            PlayerUseSkill(3);
                            menuHandler = 1;
                            break;
                        case 4: // 4번 스킬                    
                            context.AddLog("4번 스킬을 사용합니다"); // 디버깅
                            PlayerUseSkill(4);
                            menuHandler = 1;
                            break;


                        case 0: // 취소                    
                            context.AddLog("스킬창 -> 선택메뉴"); // 디버깅
                            menuHandler = 1;
                            break;
                    }


                    break;



                    //// ---------------------------인벤토리 메뉴---------------------------------------------------------
                    //case 3:
                    //    ConsoleUI.WriteMenu(InventoryMenu, "아이템 선택");
                    //    choice = ConsoleUI.ReadMenuChoice(InventoryMenu);

                    //    switch (choice)
                    //    {
                    //        case 0: // 취소                    
                    //            context.AddLog("인벤토리 -> 선택메뉴"); // 디버깅
                    //            menuHandler = 1;
                    //            break;
                    //    }

                    //    break;

            }
        }
        else if (!_isPlayerTurn)
        {
            Thread.Sleep(1000);

            if (!Enemy.IsAlive)
            {
                NextTurn();
                return;
            }
            context.AddLog("적의 턴 입니다");
            EnemyAttack();
        }
    }
}
