using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

/// <summary>
/// 프로그램의 첫 화면입니다.
/// 이 프레임워크는 게임 내용이 빠져 있으므로, 여기서는 화면 전환 구조만 보여줍니다.
/// 실습에서는 이 화면을 여러분의 게임에 맞는 타이틀 화면으로 바꿔서 사용하면 됩니다.
/// </summary>
public class PlayerInfoScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "샘플 화면으로 이동", "ConsoleUI의 다른 기능들을 보여주는 화면으로 이동합니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.PlayerInfoScene;

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("CONSOLE GAME FRAMEWORK", "C# 콘솔앱 프로젝트 프레임워크");

        ConsoleUI.WriteBox(new[]
        {
            "이 프로젝트는 게임 내용이 빠진 뼈대(프레임워크)입니다.",
            "Core, UI, Scenes 구조를 기준으로 여러분만의 게임을 채워 넣으면 됩니다.",
            "화면은 버퍼에 먼저 그린 뒤 한 번에 반영되어 깜빡임을 줄입니다."
        }, "프로젝트 안내", ConsoleColor.DarkCyan);

        ConsoleUI.WriteMenu(Menu, "시작 메뉴");
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
