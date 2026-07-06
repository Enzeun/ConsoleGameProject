using ConsoleGameFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleGameFramework.UI;
namespace ConsoleGameFramework.Scenes;

public class ScenePractice : SceneBase
{
    public override SceneKey Key => SceneKey.Practice;

    public override void Enter(GameContext context)
    {
        Console.Clear();
        context.AddLog("연습화면입니다");
    }

    public override void Render(GameContext context)
    {

        context.AddLog("연습해보자");

        ConsoleUI.WriteTitle("--- 연습화면 ---");

        ConsoleUI.WriteBox(new[]
        {
            "첫 번째 매개변수는 '열거가능한' string 이 조건이기 때문에","배열처럼 만들어서 넣으면 되는 것 같다"
        }, "여기가 제목", ConsoleColor.Green);

        ConsoleUI.WriteSubtitle("이건 보조 제목");

        ConsoleUI.WriteCentered("",ConsoleColor.Red);
        ConsoleUI.WriteCentered("이건 뭔지 모르겠는데 가운데에 쓴다네요", ConsoleColor.Blue);
        ConsoleUI.WriteRule();
        ConsoleUI.WriteStatusBar("플레이어", GameManager.Instance.Player.VitalStats.Hp, GameManager.Instance.Player.VitalStats.MaxHp);
        ConsoleUI.WriteRule();



        ConsoleUI.WriteMenu(Menu);
        ConsoleUI.WriteLog(context.Logs);
    }

    

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "연습입니다"),
        new MenuOption(2, "돌아갑시다")
    };
    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                context.AddLog("1을 눌렀습니다");
                break;
            case 2:
                GoTo(context, SceneKey.Title);
                break;
        }
    }
}
