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
        if (Text == null) 
            return;

        SetScreen();

        var changeColorAt = Text.IndexOf('╔');

        Console.Write(Text[..changeColorAt].Pastel(Color) + Text[changeColorAt..]);
    }

    public GameState GetInput()
    {
        if (Choice == null) 
            return GameState.InMenu;

        Draw();

        return Choice[InputEngine.GetInput(Choice.Keys)];
    }

    private void SetScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(WindowSize.x, WindowSize.y);
        Console.SetBufferSize(WindowSize.x, WindowSize.y);
    }
}