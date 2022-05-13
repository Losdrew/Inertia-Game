#pragma warning disable CA1416

using MyGame.Core;
using MyGame.Miscellaneous;
using MyGame.Screens;

namespace MyGame;

public class Program
{
    public static void Main()
    {
        Score score = new();
        Map map = new();
        AudioEngine audioEngine = new();

        var currentGameState = GameState.InMenu;

        while (currentGameState != GameState.Quit)
        {
            currentGameState = currentGameState switch
            {
                GameState.InMenu => Menu(),
                GameState.Start => Start(out map),
                GameState.Play => Play(map, score, audioEngine),
                GameState.Win => Win(),
                GameState.GameOver => GameOver(),
                GameState.Continue => Continue(score),
                GameState.CreateNew => CreateNew(score)
            };
        }

        Environment.Exit(0);
    }

    private static GameState Menu()
    {
        return new MainMenuScreen().GetInput();
    }

    private static GameState Win()
    {
        return new WinScreen().GetInput();
    }

    private static GameState GameOver()
    {
        return new GameOverScreen().GetInput();
    }

    private static GameState Start(out Map map)
    {
        (map = new Map()).CreateMap();
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

    private static GameState Play(Map map, Score score, AudioEngine audioEngine)
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(Map.MapWidth * 4, Map.MapHeight * 2);
        Console.SetBufferSize(Map.MapWidth * 4, Map.MapHeight * 2);

        Map currentMap = new(map); // Create a copy of map
        MovementEngine movementHandler = new();

        currentMap.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;
        movementHandler.PlayAudio += audioEngine.PlayAudio;

        score.ResetCurrent();

        return movementHandler.Move(currentMap) ? GameState.Win : GameState.GameOver;
    }
}