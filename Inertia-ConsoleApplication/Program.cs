using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Labels;
using ConsoleApplication.Engines;
using ConsoleApplication.Screens;

namespace ConsoleApplication;

internal enum GameState
{
    InMenu,
    Start,
    Play,
    Win,
    GameOver,
    Restart,
    Continue,
    CreateNew,
    Quit
}

internal static class Program
{
    public static void Main()
    {
        ControlsTip controlsTip = new();
        Map map = new(25, 10);
        Score score = new();

        SubscribeToEvents();

        AudioEngine.StartMusicPlaylist();

        var currentGameState = GameState.InMenu;

        while (true)
        {
            currentGameState = currentGameState switch
            {
                GameState.InMenu => Menu(),
                GameState.Start => Start(out map),
                GameState.Play => Play(map, score, controlsTip),
                GameState.Win => Win(),
                GameState.GameOver => GameOver(),
                GameState.Restart => Restart(score),
                GameState.Continue => Continue(score),
                GameState.CreateNew => CreateNew(score),
                _ => Quit()
            };
        }
    }

    private static void SubscribeToEvents()
    {
        CellBase.DrawCell += GraphicsEngine.DrawCell;
        CellBase.StopMovement += MovementEngine.Movement.StopMovement;

        Player.ClearCell += GraphicsEngine.ClearCell;

        Prize.Win += MovementEngine.Movement.SetWin;
        Trap.GameOver += MovementEngine.Movement.SetGameOver;

        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.DrawScore;

        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControls;

        MovementEngine.Movement.StartAnimation += AnimationEngine.StartAnimation;
    }

    private static GameState Menu()
    {
        MenuScreen mainMenuScreen = new();
        mainMenuScreen.Draw();
        return mainMenuScreen.GetInput();
    }

    private static GameState Start(out Map map)
    {
        map = new Map(25, 10);
        map.CreateMap();
        return GameState.Play;
    }

    private static GameState Play(Map map, Score score, ControlsTip controlsTip)
    {
        // Create a copy of map
        Map currentMap = new(map);

        GraphicsEngine.SetPlayZoneScreen(currentMap.Size);

        controlsTip.Draw();
        currentMap.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;

        MovementEngine.Movement.GetCurrentMap(currentMap);

        InputEngine.AllowedInput = InputType.MusicInput | InputType.MovementInput;

        return MovementEngine.Start();
    }

    private static GameState Win()
    {
        WinScreen winScreen = new();
        winScreen.Draw();
        return winScreen.GetInput();
    }

    private static GameState GameOver()
    {
        GameOverScreen gameOverScreen = new();
        gameOverScreen.Draw();
        return gameOverScreen.GetInput();
    }

    private static GameState Restart(Score score)
    {
        score.ResetCurrent();
        return GameState.Play;
    }

    private static GameState Continue(Score score)
    {
        score.Save();
        return GameState.Start;
    }

    private static GameState CreateNew(Score score)
    {
        score.ResetAll();
        return GameState.Start;
    }

    private static GameState Quit()
    {
        Environment.Exit(0);
        return GameState.Quit;
    }
}