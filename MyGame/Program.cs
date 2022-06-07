using MyGame.Core;
using MyGame.Engines;
using MyGame.Entities;
using MyGame.Miscellaneous;
using MyGame.Screens;

namespace MyGame;

public static class Program
{
    public static void Main()
    {
        ControlsTip controlsTip = new();
        Map map = new();
        Score score = new();

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

        SetScreen();

        controlsTip.Draw();
        currentMap.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;

        return MovementEngine.Start(currentMap);
    }

    private static void SetScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(ControlsTip.Width + Map.Width + Score.Width, Map.Height * 2);
        Console.SetBufferSize(ControlsTip.Width + Map.Width + Score.Width, Map.Height * 2);
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