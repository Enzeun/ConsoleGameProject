using ConsoleGameFramework.Core;
using ConsoleGameFramework.Player;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

/// <summary>
/// 프로그램의 첫 화면입니다.
/// 이 프레임워크는 게임 내용이 빠져 있으므로, 여기서는 화면 전환 구조만 보여줍니다.
/// 실습에서는 이 화면을 여러분의 게임에 맞는 타이틀 화면으로 바꿔서 사용하면 됩니다.
/// </summary>
public class PlayerInfoScene : SceneBase
{
    //private static readonly List<MenuOption> Menu = new List<MenuOption>
    //{
    //    new MenuOption(0, "뒤로가기")
    //};

    PlayerBase Player;

    public override SceneKey Key => SceneKey.PlayerInfoScene;
    public override void Enter(GameContext context)
    {
        Player = GameManager.Instance.Player;

    }
    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("플레이어 정보");

        // --------------------------- (빈칸)  ---------------------------------------------------------

        ConsoleUI.WriteLine();
        ConsoleUI.WriteLine();

        // ---------------------------플레이어 이미지---------------------------------------------------------


        ConsoleUI.WriteLine("            .----. ");
        ConsoleUI.WriteLine("            |   -| ");
        ConsoleUI.WriteLine("            '----'  ");
        ConsoleUI.WriteLine("            /   |  ");


        // ---------------------------플레이어 정보---------------------------------------------------------
        ConsoleUI.WriteKeyValue($"[{Player.JobName}]", $"[{Player.Name}]", 10);
        ConsoleUI.WriteLine($"Lv.{Player.Level}");
        ConsoleUI.WriteStatusBar("HP", Player.CurrentHp, Player.MaxHp);
        ConsoleUI.WriteStatusBar("MP", Player.CurrentMp, Player.MaxMp, 24, ConsoleColor.DarkBlue);
        if (!Player.IsmaxLevel)
        {
            ConsoleUI.WriteStatusBar("EXP", Player.CurrentExp, Player.LevelUpExp, 24, ConsoleColor.DarkYellow);
        }
        else
        {
            ConsoleUI.WriteStatusBar("EXP", 999999, 999999, 24, ConsoleColor.DarkYellow);
        }

        ConsoleUI.WriteTable(
            headers: new[] { "항목", "값" },
            rows: new List<IReadOnlyList<string>>
            {
                //new[] {"이름", $"{Player.Name}"},
                //new[] {"직업", $"{Player.JobName}"},
                //new[] {"레벨", $"{Player.Level}"},
                //new[] {"체력", $"{Player.CurrentHp} / {Player.MaxHp}"},
                //new[] {"마나", $"{Player.CurrentMp} / {Player.MaxMp}"},
                //new[] {"경험치", $"{Player.CurrentExp} / {Player.LevelUpExp}"},
                new[] {"공격력", $"{Player.FinalAttack}"},
                new[] {"방어력", $"{Player.FinalDefence}"},
                new[] {"장비한 무기", $"{Player.EquippedWeapon.Name}"},
                new[] {"장비한 방어구", $"{Player.EquippedArmor.Name}"},
            }
            );

        
        //ConsoleUI.WriteMenu(Menu, "시작 메뉴");
    }

    public override void HandleInput(GameContext context)
    {

        ConsoleUI.ReadString("아무 키를 눌러 뒤로가기");
        GoTo(context, SceneKey.Map);

    }
}
