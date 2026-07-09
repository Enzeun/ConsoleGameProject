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

public class InventoryScene : SceneBase
{
    public override SceneKey Key => SceneKey.InventoryScene;

    PlayerBase Player;

    private Dictionary<int, int> ItemMapping = new ();

    private List<MenuOption> Menu = new ();
    public override void Enter(GameContext context)
    {

        Player = GameManager.Instance.Player;

        (Menu, ItemMapping) = ItemData.MakeInventoryMenu();

       // InitializeMenu();

    }
    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        // ---------------------------타이틀 시작하는 곳---------------------------------------------------------

        ConsoleUI.WriteTitle($"아이템 인벤토리");

        // ---------------------------타이틀 끝나는 곳---------------------------------------------------------


        // ---------------------------플레이어 정보---------------------------------------------------------


        // ---------------------------메뉴---------------------------------------------------------

        ConsoleUI.WriteMenu(Menu, "사용할 아이템 선택");

        ConsoleUI.WriteToast("물약은 최대치를 넘어서까지 사용됨을 주의하세요!",ToastType.Warning);

        // ---------------------------로그---------------------------------------------------------
        //ConsoleUI.WriteLog(context.Logs);
    }

    
    //private void InitializeMenu()
    //{
    //    Menu.Clear();
    //    int count = 1;

    //    foreach (int key in Player.ConsumableInventory.Keys)
    //    {
    //        int itemcount = Player.ConsumableInventory[key];

    //        string itemName = ItemData.Data[key].Name;
            
    //        string itemDesc = ItemData.Data[key].Description;

    //        bool canUse = Player.ConsumableInventory[key] > 0;

    //        MenuOption menuOption = new MenuOption(count, $"{itemName} X {itemcount} 개", $"{itemDesc}", canUse);

    //        Menu.Add(menuOption);

    //        ItemMapping[count] = key;

    //        count++;
    //    }

    //    Menu.Add(new MenuOption(0, "취소"));
    //}
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

        Player.UseConsumableItem(key); 

        ConsoleUI.WriteLine("아이템을 사용했습니다.");
    }
}
