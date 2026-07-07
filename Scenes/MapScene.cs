using ConsoleGameFramework.Core;
using ConsoleGameFramework.Player;
using ConsoleGameFramework.UI;
using ConsoleGameProject.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Scenes;

public class MapScene : SceneBase
{
    public override SceneKey Key => SceneKey.Map;

    MapBase CurrentMap;
    MapBase NextMap;
    bool isLastMap = false;

    public override void Enter(GameContext context)
    {
        CurrentMap = GameManager.Instance.CurrentMap;
        NextMap = GameManager.Instance.Maps[GameManager.Instance.CurrentMap.NextMapId];
        context.AddLog("맵 화면 입니다.");


        MenuOption NextMapMenu = new MenuOption
        (
            2,
            "다음 맵으로 이동한다.",
            $"{NextMap.Name} 으로 이동. (레벨'{NextMap.EnterLevel}' 이상 진입 가능)",
            (GameManager.Instance.Player.Level >= NextMap.EnterLevel)
        );

        if (CurrentMap.GetType() == typeof(Castle))
        {

            isLastMap = true;

            NextMapMenu = new MenuOption
            (
            2,
            "마왕과 전투한다",
            $"보스 티켓이 있으면 전투를 시작할 수 있습니다",
            false
            );
            // 키가 있으면 전투메뉴 활성화 << 구현 필요 **
        }



        if (!Menu.Contains(NextMapMenu))
        {
            Menu[1] = NextMapMenu;
        }


    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"{CurrentMap.Name}", "이 곳은 어디?");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------


        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteKeyValue($"[{GameManager.Instance.Player.JobName}]", $"[{GameManager.Instance.Player.Name}]",  10);
        ConsoleUI.WriteStatusBar("HP", GameManager.Instance.Player.CurrentHp, GameManager.Instance.Player.MaxHp);

               

        // ---------------------------플레이어 정보---------------------------------------------------------


        // ---------------------------메뉴---------------------------------------------------------

        ConsoleUI.WriteMenu(Menu, "행동 선택");

        // ---------------------------로그---------------------------------------------------------
        ConsoleUI.WriteLog(context.Logs);
    }

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "주변을 둘러본다.", "몬스터와 조우합니다."),
        new MenuOption(2, "다음 맵으로."),
        new MenuOption(3, "인벤토리 확인."),
        new MenuOption(4, "플레이어 상태 확인."),
                

        //new MenuOption(9, "레벨업."), // 디버깅용
        //new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                //context.AddLog("1을 눌렀습니다"); // 디버깅
                GoTo(context,SceneKey.BattleScene);
                break;

            case 2:
                if (ConsoleUI.Confirm("정말 이동 하시겠습니까? *이동 한 후에는 다시 되돌아갈 수 없습니다."))
                {
                    GameManager.Instance.ChangeMap(NextMap.Id);
                    GoTo(context, SceneKey.Map);
                }
                context.AddLog("마지막 맵입니다"); // 디버깅
                break;

            case 3:

                GameManager.Instance.Player.GainExp(100);
                //GoTo(context, SceneKey.Map);
                break;


            case 9:
                GoTo(context, SceneKey.NewTitle);
                break;

            case 0:
                context.Game.RequestQuit();
                break;
        }
    }

}
