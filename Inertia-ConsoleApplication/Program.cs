using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using ConsoleApplication.Engines;
using ConsoleApplication.Screens;

namespace ConsoleApplication;

public static class Program
{
    public static void Main()
    {
        ControlsTip controlsTip = new();
        Map map = new();
        Score score = new();

        SetTargetMethods();

        AudioEngine.StartMusicPlaylist();

        var currentGameState = GameState.InMenu;

        while (true)
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

    private static void SetTargetMethods()
    {
        CellBase.DrawCell += GraphicsEngine.DrawCell;
        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.DrawScore;
        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControls;
        MovementEngine.GetMovementInput += InputEngine.GetInput;
        ScreenBase.GetScreenInput += InputEngine.GetInput;
    }

    private static GameState Menu()
    {
        MainMenuScreen mainMenuScreen = new();
        mainMenuScreen.Draw();
        return mainMenuScreen.GetInput();
    }

    private static GameState Start(out Map map)
    {
        map = new Map();
        map.CreateMap();
        return GameState.Play;
    }

    private static GameState Play(Map map, Score score, ControlsTip controlsTip)
    {
        // Create a copy of map
        Map currentMap = new(map);

        GraphicsEngine.SetPlayZoneScreen();

        controlsTip.Draw();
        currentMap.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;

        return MovementEngine.Start(currentMap);
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