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

    public override void Enter(GameContext context)
    {
        context.AddLog("맵 화면 입니다.");

        bool isLastMap = false;

        MenuOption NextMapMenu = new MenuOption
            (

            2,
            "다음 맵으로 이동한다.",
            $"{GameManager.Instance.Maps[GameManager.Instance.CurrentMap.NextMapId]} 으로 이동",
            (GameManager.Instance.Player.Level >= GameManager.Instance.CurrentMap.EnterLevel)
        );

        string NextMap = $"{GameManager.Instance.Maps[GameManager.Instance.CurrentMap.NextMapId]} 으로 이동";

        if (GameManager.Instance.CurrentMap.GetType() == typeof(Castle))
        {

            isLastMap = true;

            NextMapMenu = new MenuOption
            (
            2,
            "마왕과 전투한다",
            $"{GameManager.Instance.Maps[GameManager.Instance.CurrentMap.NextMapId]} 으로 이동",
            false
            );
            // 키가 있으면 전투메뉴 활성화 구현 필요 **
        }
        Menu.Insert(1, NextMapMenu);


    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteMenu(Menu, "시작 메뉴");

    }

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "주변을 둘러본다."),

        new MenuOption(9, "타이틀로", "첫 화면으로 돌아갑니다."),
        new MenuOption(0, "종료", "프로그램을 종료합니다.")
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
            case 9:
                GoTo(context, SceneKey.Title);
                break;
            case 0:
                context.Game.RequestQuit();
                break;
        }
    }

}
