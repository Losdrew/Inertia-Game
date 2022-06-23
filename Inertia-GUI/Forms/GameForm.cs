using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.Screens;

namespace GUI.Forms;

public partial class GameForm : FormBase
{
    public GameForm()
    {
        InitializeComponent();

        SetTargetMethods();

        GraphicsEngine.GetGameForm(this);

        Map = new Map();
        Score = new Score();
    }

    private Map Map { get; set; }

    private Score Score { get; }

    public void StartGame()
    {
        Map = new Map();
        Map.CreateMap();
        Play();
    }

    public void Restart()
    {
        Score.ResetCurrent();
        Play();
    }

    public void Continue()
    {
        Score.Save();
        StartGame();
    }

    public void CreateNew()
    {
        Score.ResetAll();
        StartGame();
    }

    private void Play()
    {
        // Create a copy of map
        Map currentMap = new(Map);

        GraphicsEngine.SetMapBox();

        currentMap.Draw();
        Score.Draw();
        new ControlsTip().Draw();

        currentMap.UpdateScore += Score.Update;

        MovementEngine.Start(currentMap);

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

    private void SetTargetMethods()
    {
        Player.StartMovementAnimation += GraphicsEngine.StartAnimationTimer;
        AnimationTimer.Tick += GraphicsEngine.DoPlayerAnimation;
        AnimationTimer.Interval = 1;

        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.ClearCell += GraphicsEngine.ClearCell;
        CellBase.StopMovement += MovementEngine.SetMovementUnavailable;

        Prize.Win += Win;
        Trap.GameOver += GameOver;
        
        MovementEngine.Win += Win;
        MovementEngine.GameOver += GameOver;

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;
    }
}