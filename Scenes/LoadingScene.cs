using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameProject.Scenes;

public class LoadingScene : SceneBase
{
    public override SceneKey Key => SceneKey.Loading;

    public SceneKey NextSceneKey = SceneKey.Map;

   

    public override void Enter(GameContext context)
    {

    }

    public override void Render(GameContext context)
    {
        ConsoleUI.Clear();

        ConsoleUI.WriteRule('=', ConsoleColor.Blue);
        ConsoleUI.WriteBox(["로딩 중..."], "Loading...", ConsoleColor.Yellow);
        ConsoleUI.WriteRule('=', ConsoleColor.Blue);



    }

    public override void HandleInput(GameContext context)
    {
        Thread.Sleep(1000);
        GoTo(context, NextSceneKey);
    }
}
