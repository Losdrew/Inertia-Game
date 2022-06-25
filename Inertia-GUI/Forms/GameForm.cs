using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.Screens;

namespace GUI.Forms;

internal partial class GameForm : FormBase
{
    private Map _map;
    private readonly Score _score;

    public GameForm()
    {
        InitializeComponent();

        SubscribeToEvents();

        _map = new Map();
        _score = new Score();

        GraphicsEngine.GetGameForm(this);

        AnimationEngine.GetAnimationTimer(AnimationTimer);
    }

    public void StartGame()
    {
        _map = new Map();
        _map.CreateMap();
        Play();
    }

    public void Restart()
    {
        _score.ResetCurrent();
        Play();
    }

    public void Continue()
    {
        _score.Save();
        StartGame();
    }

    public void CreateNew()
    {
        _score.ResetAll();
        StartGame();
    }

    private void Play()
    {
        // Create a copy of map
        Map currentMap = new(_map);

        GraphicsEngine.SetMapBox();

        currentMap.Draw();
        _score.Draw();
        new ControlsTip().Draw();

        currentMap.UpdateScore += _score.Update;

        MovementEngine.GetCurrentMap(currentMap);

        // Start accepting movement and music input
        InputEngine.AllowedInput = InputType.MovementInput | InputType.MusicInput;
    }

    private static void Win()
    {
        new WinScreenForm().MakeActive();
    }

    private static void GameOver()
    {
        new GameOverScreenForm().MakeActive();
    }

    private void SubscribeToEvents()
    {
        AnimationTimer.Tick += AnimationEngine.PlayAnimation;
        AnimationTimer.Interval = 1;

        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.ClearCell += GraphicsEngine.ClearCell;
        CellBase.StopMovement += MovementEngine.StopMovement;

        Prize.Win += Win;
        Trap.GameOver += GameOver;

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;
    }
}  