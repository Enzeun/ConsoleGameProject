using ConsoleGameFramework.Core;
using ConsoleGameFramework.Player;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

public class NewTitleScene : SceneBase
{
    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "모험을 시작합니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override SceneKey Key => SceneKey.NewTitle;

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteTitle("", "이 게임은 디밸로켓 수강생의 콘솔 게임 프로젝트 입니다");
        ConsoleUI.WriteBox(new[] { "이 게임은 정말 흔하디 흔한", "어디서든 볼 수 있던", "흔한 RPG 게임 입니다" }, "늘 보던 흔한 RPG", ConsoleColor.Magenta);




        //ConsoleUI.WriteMenu(Menu, "시작 메뉴");
    }

    private static readonly List<MenuOption> JobMenu = new List<MenuOption>
    {
        new MenuOption(1, "전사", "전체적인 밸런스가 좋은 직업입니다."),
        new MenuOption(2, "마법사", "공격력은 낮지만 강한 스킬을 가지고 있습니다."),

        new MenuOption(0, "종료", "프로그램을 종료합니다.")
    };

    public override void HandleInput(GameContext context)
    {
        string nameSeletor = "";
        bool nameConfirmed = false;
        while (!nameConfirmed)
        {
            nameSeletor = ConsoleUI.ReadString("이름을 입력하세요");
            if (nameSeletor == "")
            {
                ConsoleUI.WriteToast("이름을 입력하세요",ToastType.Error);
            }
            else 
            {
                nameConfirmed = ConsoleUI.Confirm($"당신의 이름은 '{nameSeletor}'입니까?");
            }
        }

        // 직업 정하기 루프

        ConsoleUI.WriteMenu(JobMenu);

        int jobChoice = ConsoleUI.ReadMenuChoice(JobMenu);

        switch (jobChoice)
        {
            case 1:
                GameManager.Instance.InitializePlayer(new Warrior());
                break;

            case 2:
                GameManager.Instance.InitializePlayer(new Mage());
                break;

            case 0:
                context.Game.RequestQuit();
                break;
        }

        GameManager.Instance.Player.Name = nameSeletor;


        ConsoleUI.WriteMenu(Menu);

        int Choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (Choice)
        {
            case 1:
                GoTo(context, SceneKey.Map);
                break;

            case 0:
                context.Game.RequestQuit();
                break;
        }
    }
}
