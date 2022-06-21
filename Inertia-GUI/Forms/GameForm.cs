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
    private Map Map { get; set; }

    private Score Score { get; }

    public GameForm()
    {
        InitializeComponent();

        SetTargetMethods();

        AudioEngine.StartMusicPlaylist();

        GraphicsEngine.GameForm = this;

        Map = new Map();
        Score = new Score();
    }

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
    }

    private static void Win()
    {
        new WinScreenForm().MakeActive();
    }

    private static void GameOver()
    {
        new GameOverScreenForm().MakeActive();
    }

    private void StartMovementTimer()
    {
        MovementTimer.Start();
    }

    private void StopMovementTimer()
    {
        MovementTimer.Stop();
    }

    private void SetTargetMethods()
    {
        KeyDown += InputEngine.ReadKey;

        MovementTimer.Tick += MovementEngine.Move;
        MovementTimer.Interval = MovementEngine.FrameMs;

        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.ClearCell += GraphicsEngine.ClearCell;

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;

        MovementEngine.Win += Win;
        MovementEngine.GameOver += GameOver;
        MovementEngine.StartMovement += StartMovementTimer;
        MovementEngine.StopMovement += StopMovementTimer;
    }
}