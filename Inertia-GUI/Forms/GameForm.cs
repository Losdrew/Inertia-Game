using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.Screens;

namespace GUI.Forms;

internal partial class GameForm : FormBase
{
    private static readonly Score Score = new();
    private Map _map;

    public GameForm()
    {
        InitializeComponent();

        SubscribeToEvents();

        _map = new Map();

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
        Score.Save();
        StartGame();
    }

    private void Play()
    {
        // Create a copy of map
        Map currentMap = new(_map);

        GraphicsEngine.SetMapBox();

        currentMap.Draw();
        Score.Draw();
        new ControlsTip().Draw();

        currentMap.UpdateScore += Score.Update;

        MovementEngine.Movement.GetCurrentMap(currentMap);

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

        Prize.Win += MovementEngine.Movement.SetWin;
        Trap.GameOver += MovementEngine.Movement.SetGameOver;

        MovementEngine.Movement.Win += Win;
        MovementEngine.Movement.GameOver += GameOver;
        MovementEngine.Movement.StartAnimation += AnimationEngine.StartAnimation; 

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;
    }

    private void AudioVolumeSlider_VolumeChanged(object sender, EventArgs e)
    {
        AudioEngine.ChangeVolume(AudioVolumeSlider.Volume);
    }
}