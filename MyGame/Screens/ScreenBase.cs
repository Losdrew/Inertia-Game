using MyGame.Core;
using MyGame.Miscellaneous;
using Pastel;

namespace MyGame.Screens;

public abstract class ScreenBase : VisualObject
{
    protected (int x, int y) WindowSize { get; init; }

    protected string? Text { get; init; }

    protected Dictionary<ConsoleKey, GameState>? Choice { get; init; }

    public override void Draw()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(WindowSize.x, WindowSize.y);
        Console.SetBufferSize(WindowSize.x, WindowSize.y);

        if (Text == null) return;

        var changeColorAt = Text.IndexOf('╔');

        Console.Write(Text[..changeColorAt].Pastel(Color) + Text[changeColorAt..]);
    }

    public GameState GetInput()
    {
        Draw();

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (Choice != null && Choice.ContainsKey(key))
                return Choice[key];
        }
    }
}