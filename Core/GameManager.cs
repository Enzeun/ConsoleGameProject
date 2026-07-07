using ConsoleGameFramework.Scenes;
using ConsoleGameFramework.UI;
using ConsoleGameFramework.Player;
using ConsoleGameProject.Map;
using ConsoleGameProject.Scenes;

namespace ConsoleGameFramework.Core;


/// <summary>
/// 게임의 전체 흐름을 담당하는 클래스입니다.
///
/// 역할:
/// 1. Scene 등록
/// 2. 현재 Scene 실행
/// 3. Scene 전환
/// 4. 프로그램 종료 요청 처리
///
/// 참고: 이 클래스는 프로그램 전체에서 단 하나만 존재해야 하므로 Singleton 패턴으로 작성되어 있습니다.
/// (생성자를 private으로 막고, 정적 Instance 프로퍼티로만 접근을 허용)
/// </summary>
public class GameManager
{
    // ----------------------------------------------------------------------------------------------
    // 맵 정보 등록
    public readonly Dictionary<int, MapBase> Maps = new Dictionary<int, MapBase>();
    public MapBase CurrentMap { get; private set; }

    private void RegisterMaps()
    {
        AddMaps(new GrassField());
        AddMaps(new Forest());
        AddMaps(new Grave());
        AddMaps(new Castle());
        AddMaps(new Dummy());

        CurrentMap = Maps[001];
    }
    private void AddMaps(MapBase map)
    {
        Maps[map.Id] = map;
    }
    public void ChangeMap(int id)
    {
        if (Maps.TryGetValue(id, out MapBase? map))
            CurrentMap = map;
        else // 예외 발생 시 더미 맵으로 덮어쓰기
        {
            Context.AddLog("해당 맵은 없는 맵입니다.");
            CurrentMap = Maps[999];
        }
        ConsoleUI.WriteLog(Context.Logs);
    }



    // ----------------------------------------------------------------------------------------------
    // ----------------------------------------------------------------------------------------------
    // ----------------------------------------------------------------------------------------------
    // ----------------------------------------------------------------------------------------------


    // ----------------------------------------------------------------------------------------------

    public PlayerBase Player;

    public void InitializePlayer(PlayerBase job)
    {
        Player = job;
    }

    // ----------------------------------------------------------------------------------------------

    /// <summary>
    /// 아래는 기본구현이 완료되어있던 것 입니다
    /// </summary>
    private readonly Dictionary<SceneKey, IScene> _scenes = new Dictionary<SceneKey, IScene>();
    private IScene? _currentScene;


    /// <summary>
    /// 프로그램 전체에서 하나만 사용하는 GameManager 인스턴스입니다.
    /// </summary>
    public static GameManager Instance { get; } = new GameManager();

    private GameManager()
    {
        Context = new GameContext(this);
        RegisterScenes();
        RegisterMaps();
    }

    public GameContext Context { get; }

    /// <summary>
    /// 게임에서 사용할 화면들을 등록합니다.
    /// 새 화면을 만들었다면 이곳에 AddScene(new MyScene()) 형식으로 추가합니다.
    /// </summary>
    private void RegisterScenes()
    {
        AddScene(new TitleScene());
        AddScene(new NewTitleScene());
        AddScene(new SampleScene());
        AddScene(new ScenePractice());
        AddScene(new MapScene());
        AddScene(new LoadingScene());
        AddScene(new PopUpNaxtMapScene());
    }

    private void AddScene(IScene scene)
    {
        _scenes[scene.Key] = scene;
    }

    /// <summary>
    /// 프로그램의 메인 루프입니다.
    /// 현재 Scene을 그리고(Render), 화면에 반영(Present), 입력을 처리(HandleInput)하는 과정을 반복합니다.
    /// </summary>
    public void Run()
    {
        ChangeScene(SceneKey.NewTitle);

        while (Context.IsRunning && _currentScene is not null)
        {
            _currentScene.Render(Context);
            ConsoleUI.Present();
            _currentScene.HandleInput(Context);
        }

        ConsoleUI.Clear();
        ConsoleUI.WriteTitle("게임 종료", "플레이 해주셔서 감사합니다.");
        //ConsoleUI.WriteBox(new[]
        //{
        //    "C# 콘솔 게임 프레임워크가 종료되었습니다.",
        //    "Core, UI, Scenes 구조를 기준으로 기능을 확장할 수 있습니다."
        //}, "Good Bye", ConsoleColor.DarkCyan);
        //ConsoleUI.Present();
    }

    /// <summary>
    /// 다른 화면으로 전환합니다.
    /// </summary>
    public void ChangeScene(SceneKey key)
    {
        if (!_scenes.TryGetValue(key, out IScene? nextScene))
        {
            Context.AddLog($"등록되지 않은 화면입니다: {key}");
            return;
        }

        _currentScene?.Exit(Context);
        _currentScene = nextScene;
        _currentScene.Enter(Context);
    }

    /// <summary>
    /// 게임 종료를 요청합니다.
    /// </summary>
    public void RequestQuit()
    {
        Context.IsRunning = false;
    }
}
