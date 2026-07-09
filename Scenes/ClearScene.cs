using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;

namespace ConsoleGameFramework.Scenes;

/// <summary>
/// 프로그램의 첫 화면입니다.
/// 이 프레임워크는 게임 내용이 빠져 있으므로, 여기서는 화면 전환 구조만 보여줍니다.
/// 실습에서는 이 화면을 여러분의 게임에 맞는 타이틀 화면으로 바꿔서 사용하면 됩니다.
/// </summary>
public class ClearScene : SceneBase
{
    public override void Enter(GameContext context)
    {
        ConsoleUI.WriteLine("클리어 씬 입장");
    }

    public override SceneKey Key => SceneKey.ClearScene;

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("Game Clear!", "축하합니다!");

    }

    public override void HandleInput(GameContext context)
    {
        ConsoleUI.ReadString("이 게임을 여기까지 플레이 하시다니. 정말 감사합니다.");
        context.Game.RequestQuit();

    }
}

