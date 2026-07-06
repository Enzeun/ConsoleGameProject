using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

public class NewTitleScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "새로운 타이틀 입니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.NewTitle;

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteBox(new[] { "이 게임은 정말 흔하디 흔한", "어디서든 볼 수 있던", "흔한 RPG 게임 입니다" }, "늘 보던 흔한 RPG",ConsoleColor.Magenta);

        ConsoleUI.WriteMenu(Menu, "시작 메뉴");

        ConsoleUI.WriteTitle("", "이 게임은 디밸로켓 수강생의 콘솔 게임 프로젝트 입니다");
    }

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                GoTo(context, SceneKey.Sample);
                break;

            case 0:
                context.Game.RequestQuit();
                break;
        }
    }
}
