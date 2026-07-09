using ConsoleGameFramework.Core;
using ConsoleGameFramework.Player;
using ConsoleGameFramework.UI;
using ConsoleGameProject.Item;
using ConsoleGameProject.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Scenes;

public class EquipmentScene : SceneBase
{
    public override SceneKey Key => SceneKey.EquipmentScene;

    PlayerBase Player;

    private Dictionary<int, int> ItemMapping = new ();

    private List<MenuOption> Menu = new ();
    public override void Enter(GameContext context)
    {

        Player = GameManager.Instance.Player;

        (Menu, ItemMapping) = ItemData.MakeEquipmentMenu();

       // InitializeMenu();

    }
    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"장비 인벤토리");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------


        // ---------------------------플레이어 정보---------------------------------------------------------


        // ---------------------------메뉴---------------------------------------------------------

        ConsoleUI.WriteMenu(Menu, "장착할 장비 선택");

        // ---------------------------로그---------------------------------------------------------
        //ConsoleUI.WriteLog(context.Logs);
    }

  
    public override void HandleInput(GameContext context)
    {
        int choice = ConsoleUI.ReadMenuChoice(Menu);

        if (choice == 0)
            GoTo(context, SceneKey.Map);

        else
        {            
            UseItem(choice);
            GoTo(context, SceneKey.Map);
        }

    }

    // 갯수가 없어서 사용불가인 아이템은 메뉴에서부터 차단되어있음.
    public void UseItem(int num)
    {
        int key = ItemMapping[num];

        Player.EquipItem(key);          

        ConsoleUI.WriteLine("아이템을 사용했습니다.");
    }
}
