using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Labels;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.JsonStorage;
using GUI.Forms.Screens;
using GUI.Properties;
using GUI.Storage.Objects;

namespace GUI.Forms;

internal enum GameMode
{
    RandomMaps,
    PremadeMaps
}

internal partial class GameForm : FormBase
{
    public User User = new();

    private readonly Score _score = new();
    private Map? _map;
    
    public GameForm()
    {
        GraphicsEngine.GameForm = this;

        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.StopMovement += MovementEngine.StopMovement;

        Player.ClearCell += GraphicsEngine.ClearCell;

        Prize.Win += MovementEngine.Movement.SetWin;
        Trap.GameOver += MovementEngine.Movement.SetGameOver;

        MovementEngine.Movement.Win += Win;
        MovementEngine.Movement.GameOver += GameOver;
        MovementEngine.Movement.StartAnimation += AnimationEngine.StartAnimation;

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;
    }

    public static GameMode CurrentGameMode { get; private set; }

    public static bool IsEndingGameSession()
    {
        return MessageBox.Show(
            Resources.EndGameSessionText,
            Resources.EndGameSessionCaption,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes;
    }

    public void SaveUserInfo()
    {
        if (User.HasResults())
        {
            LeaderboardsForm.SaveUser(User);
        }

        _score.ResetAll();
        User = new User(User.Name);
    }

    public void StartGame(GameMode gameMode, Map? map = null)
    {
        CurrentGameMode = gameMode;
        Initialize(map);
        Play();
    }

    public void Restart()
    {
        ResetCurrentScore();
        Play();
    }

    public void Continue()
    {
        SaveScore();
        StartGame(GameMode.RandomMaps);
    }

    public void CreateNew()
    {
        SaveScore();
        SaveUserInfo();
        StartGame(GameMode.RandomMaps);
    }

    public void ResetCurrentScore()
    {
        _score.ResetCurrent();
    }

    private void SaveScore()
    {
        _score.Save();
        User.PrizeCount = _score.TotalScore;
    }

    private void Play()
    {
        if (_map is null)
        {
            return;
        }

        // Create a copy of map
        Map currentMap = new(_map);

        GraphicsEngine.SetMapBox(currentMap.Size);

        currentMap.Draw();
        _score.Draw();
        new ControlsTip().Draw();

        currentMap.UpdateScore += _score.Update;

        MovementEngine.Movement.GetCurrentMap(currentMap);

        // Start accepting movement and music input
        InputEngine.AllowedInput = InputType.MovementInput | InputType.MusicInput | InputType.PauseInput;
    }

    private void Win()
    {
        User.CompletedLevelsCount++;
        new WinScreenForm().MakeActive();
    }

    private void GameOver()
    {
        User.GameOverCount++;
        new GameOverScreenForm().MakeActive();
    }

    private void Initialize(Map? map)
    {
        // Ensure that form is empty before initialization
        Controls.Clear();

        InitializeComponent();

        if (CurrentGameMode == GameMode.RandomMaps)
        {
            var (width, height) = OptionsForm.Options.MapSize;
            _map = new Map(width, height).CreateMap();
        }

        if (CurrentGameMode == GameMode.PremadeMaps)
        {
            _map = map;
        }

        AnimationTimer.Interval = 1;
        AnimationTimer.Tick += AnimationEngine.PlayAnimation;
        AnimationEngine.AnimationTimer = AnimationTimer;
    }

    private void AudioVolumeSlider_VolumeChanged(object sender, EventArgs e)
    {
        AudioEngine.ChangeVolume(AudioVolumeSlider.Volume);
    }

    private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        FormBase_FormClosing(sender, e);
        SaveUserInfo();
    }
}