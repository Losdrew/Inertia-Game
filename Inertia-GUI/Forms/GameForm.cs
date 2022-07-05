using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Labels;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.Screens;
using GUI.Properties;
using GUI.Storage.Objects;
using GUI.Storage.Repositories;

namespace GUI.Forms;

internal partial class GameForm : FormBase
{
    public static User User = new();
    public static readonly UserRepository UserRepository = new();

    private static Map _map = new();
    private static readonly Score Score = new();

    public GameForm()
    {
        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.StopMovement += MovementEngine.StopMovement;

        Player.ClearCell += GraphicsEngine.ClearCell;

        Prize.Win += MovementEngine.Movement.SetWin;
        Trap.GameOver += MovementEngine.Movement.SetGameOver;

        MovementEngine.Movement.Win += Win;
        MovementEngine.Movement.GameOver += GameOver;
        MovementEngine.Movement.StartAnimation += AnimationEngine.StartAnimation; 

        GameForm.Score.DrawScore += GraphicsEngine.DrawScore;
        GameForm.Score.UpdateScore += GraphicsEngine.UpdateScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControlsTip;
    }

    public static void SaveUserInfo()
    {
        if (User.HasResults())
        {
            User.SavedDateTime = DateTime.Now;
            UserRepository.SaveUser(User);
        }

        Score.ResetAll();
        User = new User(User.Name);
    }

    public static bool IsEndingGameSession()
    {
        if (MessageBox.Show(
                Resources.EndGameSessionText,
                Resources.EndGameSessionCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            return true;
        }
        
        return false;
    }

    public void StartGame()
    {
        Initialize();
        Play();
    }

    public void Restart()
    {
        Score.ResetCurrent();
        Play();
    }

    public void Continue()
    {
        SaveScore();
        StartGame();
    }

    public void CreateNew()
    {
        SaveScore();
        SaveUserInfo();
        StartGame();
    }

    private static void SaveScore()
    {
        Score.Save();
        User.PrizeCount = Score.TotalScore;
    }

    private static void Play()
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
        InputEngine.AllowedInput = InputType.MovementInput | InputType.MusicInput | InputType.PauseInput;
    }

    private static void Win()
    {
        User.CompletedLevelsCount++;
        new WinScreenForm().MakeActive();
    }

    private static void GameOver()
    {
        User.GameOverCount++;
        new GameOverScreenForm().MakeActive();
    }

    private void Initialize()
    {
        // Ensure that form is empty before initialization
        Controls.Clear();

        InitializeComponent();

        _map = new Map().CreateMap();

        AnimationTimer.Tick += AnimationEngine.PlayAnimation;
        AnimationTimer.Interval = 1;

        // Get references to game form and animation timer for engines
        GraphicsEngine.GameForm = this;
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