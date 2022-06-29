using CommonCodebase.Core;
using ConsoleApplication.Engines;
using ConsoleApplication.Properties;
using ConsoleTableExt;
using Pastel;
using System.Drawing;
using System.Text;

namespace ConsoleApplication.Screens;

internal abstract class ScreenBase : VisualObject
{
    private const int Width = 118;
    private const int Height = 44;

    protected ScreenBase()
    {
        MenuItems = new List<MenuItem>();
    }

    protected Color Color { get; init; }

    protected string? Label { get; init; }

    protected List<MenuItem> MenuItems { get; init; }

    public override void Draw()
    {
        GraphicsEngine.SetScreen(Width, Height);

        foreach (var section in GenerateScreenContent())
        {
            GraphicsEngine.DrawCentered(Width, section);
        }
    }

    public GameState GetInput()
    {
        InputEngine.AllowedInput = InputType.MusicInput | InputType.ScreenInput;

        InputEngine.ScreenControls.Clear();

        foreach (var item in MenuItems)
        {
            InputEngine.ScreenControls.Add(item.Key, item.State);
        }

        return (GameState)InputEngine.GetInput();
    }

    private List<string> GenerateScreenContent()
    {
        // Get titles of all menu items in MenuItems list
        var titles = MenuItems.Select(item => item.Title).ToList();

        return new List<string>
        {
            Label.Pastel(Color),
            BuildMenuTable(titles).ToString(),
            Resources.SkiRunner
        };
    }

    private static StringBuilder BuildMenuTable(List<string> titles)
    {
        return ConsoleTableBuilder
            .From(titles)
            .WithColumn("Choose an option")
            .WithTextAlignment(new Dictionary<int, TextAligntment>
            {
                { 0, TextAligntment.Center }
            })
            .WithCharMapDefinition(new Dictionary<CharMapPositions, char>
            {
                { CharMapPositions.BottomLeft, '╚' },
                { CharMapPositions.BottomRight, '╝' },
                { CharMapPositions.BorderLeft, '║' },
                { CharMapPositions.BorderRight, '║' },
                { CharMapPositions.BorderBottom, '═' }
            })
            .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char>
            {
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