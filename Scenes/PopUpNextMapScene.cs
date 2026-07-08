using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Scenes;

public class PopUpNaxtMapScene:SceneBase
{
    public override SceneKey Key => SceneKey.PopUpNaxtMap;

            

    public override void Enter(GameContext context)
    {
        
    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteRule('=',ConsoleColor.Blue);
        ConsoleUI.WriteBox(["정말 이동하시겠습니까?", ], "이동 한 후에는 다시 되돌아갈 수 없습니다.", ConsoleColor.Yellow);
        ConsoleUI.WriteRule('=',ConsoleColor.Blue);


        ConsoleUI.WriteMenu(Menu);
    }

    private static readonly List<MenuOption> Menu = new List<MenuOption>
    {
        new MenuOption(1, "네."),
        new MenuOption(2, "아니오.")
    };

    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        switch (choice)
        {
            case 1:
                GameManager.Instance.ChangeMap(GameManager.Instance.Maps[GameManager.Instance.CurrentMap.NextMapKey].Key);
                GoTo(context, SceneKey.Map);
                break;

            case 2:
                GoTo(context, SceneKey.Map);
                break;
        }
    }
}
