using MyGame.Core;
using MyGame.Miscellaneous;
using MyGame.Screens;

namespace MyGame;

public static class Program
{
    public static void Main()
    {
        Map map = new();
        Score score = new();
        AudioEngine audioEngine = new();
        MovementEngine movementEngine = new();

        movementEngine.PlayAudio += audioEngine.PlayAudio;

        var currentGameState = GameState.InMenu;

        while (true)
        {
            currentGameState = currentGameState switch
            {
                GameState.InMenu => Menu(),
                GameState.Start => Start(out map),
                GameState.Play => Play(map, score, movementEngine),
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
        return new MainMenuScreen().GetInput();
    }

    private static GameState Start(out Map map)
    {
        map = new Map();
        map.CreateMap();
        return GameState.Play;
    }

    private static GameState Play(Map map, Score score, MovementEngine movementEngine)
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(Map.MapWidth * 4, Map.MapHeight * 2);
        Console.SetBufferSize(Map.MapWidth * 4, Map.MapHeight * 2);

        Map currentMap = new(map); // Create a copy of map

        currentMap.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;

        return movementEngine.Move(currentMap) ? GameState.Win : GameState.GameOver;
    }

    private static GameState Win()
    {
        return new WinScreen().GetInput();
    }

    private static GameState GameOver()
    {
        return new GameOverScreen().GetInput();
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