using System.Text;
using CommonCodebase;
using CommonCodebase.Core;
using CommonCodebase.Engines;
using ConsoleTableExt;
using ConsoleApplication.Engines;

namespace ConsoleApplication.Screens;

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

    public static InputHandler<ConsoleKey>? GetScreenInput;

    public override void Draw()
    {
        GraphicsEngine.SetScreen(Width, Height);

        foreach (var section in ScreenText)
            GraphicsEngine.DrawCentered(Width, section);
    }

    public GameState GetInput()
    {
        return MenuItems.GetState((ConsoleKey)GetScreenInput?.Invoke()!);
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
                { HeaderCharMapPositions.TopLeft, '╔' },
                { HeaderCharMapPositions.TopRight, '╗' },
                { HeaderCharMapPositions.BottomLeft, '╠' },
                { HeaderCharMapPositions.BottomRight, '╣' },
                { HeaderCharMapPositions.BorderTop, '═' },
                { HeaderCharMapPositions.BorderRight, '║' },
                { HeaderCharMapPositions.BorderBottom, '═' },
                { HeaderCharMapPositions.BorderLeft, '║' }
            })
            .Export();
    }
}