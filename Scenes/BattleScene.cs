using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Scenes;

internal class BattleScene:SceneBase
{
    public override SceneKey Key => SceneKey.BattleScene;

    public override void Enter(GameContext context)
    {

    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"전투 시작!!", "몬스터와 조우했습니다!");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------

        // ---------------------------몬스터 정보---------------------------------------------------------

        ConsoleUI.WriteLine("  .----.");
        ConsoleUI.WriteLine("  (O  O)");
        ConsoleUI.WriteLine("  / ()  |");
        ConsoleUI.WriteLine(" /   /|  |");
        ConsoleUI.WriteLine("|___| |___|");

        // 몬스터 이름 : HP 바
        ConsoleUI.WriteStatusBar("HP", GameManager.Instance.Player.CurrentHp, GameManager.Instance.Player.MaxHp);

        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();


        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteKeyValue($"[{GameManager.Instance.Player.JobName}]", $"[{GameManager.Instance.Player.Name}]", 10);
        ConsoleUI.WriteStatusBar("HP", GameManager.Instance.Player.CurrentHp, GameManager.Instance.Player.MaxHp);





        

        // ---------------------------로그---------------------------------------------------------
        //ConsoleUI.WriteLog(context.Logs);
    }

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "기본 공격"),
        new MenuOption(2, "스킬 사용."),
        new MenuOption(3, "인벤토리."),                

        //new MenuOption(9, "레벨업."), // 디버깅용
        //new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
        //new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };
    public override void HandleInput(GameContext context)
    {
        // ---------------------------기본 메뉴---------------------------------------------------------

        ConsoleUI.WriteMenu(Menu, "행동 선택");
        ConsoleUI.WriteLog(context.Logs);

        // ---------------------------스킬 메뉴---------------------------------------------------------
        // ---------------------------인벤토리 메뉴---------------------------------------------------------
    }

}
