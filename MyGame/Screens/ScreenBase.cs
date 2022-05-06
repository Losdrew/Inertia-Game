#pragma warning disable CA1416

using MyGame.Core;
using MyGame.Miscellaneous;

namespace MyGame.Screens;

public abstract class ScreenBase : VisualObject
{
    protected string? Path { get; init; }

    protected (int x, int y) WindowSize { get; init; }

    protected Dictionary<ConsoleKey, GameState>? Choice { get; init; }

    public override void Draw()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(WindowSize.x, WindowSize.y);
        Console.SetBufferSize(WindowSize.x, WindowSize.y);

        ApplyColor();

        Console.WriteLine();

        foreach (var line in File.ReadLines(Path))
        {
            if (string.IsNullOrEmpty(line))
                ResetColor();

            Console.WriteLine(line);
        }
    }

    public GameState GetInput()
    {
        Draw();

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (Choice.ContainsKey(key))
                return Choice[key];
        }
    }
}