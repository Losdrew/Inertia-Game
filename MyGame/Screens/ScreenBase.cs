using System.Text;
using ConsoleTableExt;
using MyGame.Core;
using MyGame.Engines;

namespace MyGame.Screens;

public abstract class ScreenBase : VisualObject
{
    private const int Width = 118;
    private const int Height = 44;

    protected MenuItems MenuItems { get; init; }

    protected LinkedList<string> ScreenText { get; }

    protected ScreenBase()
    {
        MenuItems = new MenuItems();
        ScreenText = new LinkedList<string>();

        ScreenText.AddFirst(Resources.SkiRunner);
    }

    public override void Draw()
    {
        SetScreen();

        foreach (var section in ScreenText)
            DrawCentered(section);
    }

    public GameState GetInput()
    {
        return MenuItems.GetState(InputEngine.GetInput(MenuItems.Keys()));
    }

    protected static StringBuilder BuildMenuTable(List<string> titles)
    {
        return ConsoleTableBuilder
            .From(titles)
            .WithColumn("Choose an option")
            .WithTextAlignment(new Dictionary<int, TextAligntment> {
                { 0, TextAligntment.Center }
            })
            .WithCharMapDefinition(new Dictionary<CharMapPositions, char> {
                { CharMapPositions.BottomLeft, '╚' },
                { CharMapPositions.BottomRight, '╝' },
                { CharMapPositions.BorderLeft, '║' },
                { CharMapPositions.BorderRight, '║' },
                { CharMapPositions.BorderBottom, '═' }
            })
            .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char> {
                {HeaderCharMapPositions.TopLeft, '╔' },
                {HeaderCharMapPositions.TopRight, '╗' },
                {HeaderCharMapPositions.BottomLeft, '╠' },
                {HeaderCharMapPositions.BottomRight, '╣' },
                {HeaderCharMapPositions.BorderTop, '═' },
                {HeaderCharMapPositions.BorderRight, '║' },
                {HeaderCharMapPositions.BorderBottom, '═' },
                {HeaderCharMapPositions.BorderLeft, '║' }
            })
            .Export();
    }

    private static void SetScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(Width, Height);
        Console.SetBufferSize(Width, Height);
    }

    private static void DrawCentered(string text)
    {
        foreach (var line in text.Split('\n'))
            Console.WriteLine("{0," + (Width / 2 + line.Length / 2) + "}", line);
    }
}