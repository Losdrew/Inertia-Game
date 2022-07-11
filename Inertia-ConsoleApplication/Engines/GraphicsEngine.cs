using CommonCodebase.Entities;
using CommonCodebase.Labels;
using ConsoleApplication.Properties;
using Pastel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication.Engines;

internal static class GraphicsEngine
{
    private const int LeftSectionWidth = 38;
    private const int RightSectionWidth = 32;

    private static int _playZoneWidth;
    private static int _playZoneHeight;

    private static int _mapLocationX;
    private static int _mapLocationY;

    private static (int Width, int Height) _mapSize;

    private static (int Width, int Height) MapSize
    {
        get => _mapSize;
        set
        {
            if (_mapSize == value)
            {
                return;
            }

            _mapSize = value;

            _playZoneWidth = LeftSectionWidth + _mapSize.Width + RightSectionWidth;
            _playZoneHeight = _mapSize.Height * 2;

            _mapLocationX = LeftSectionWidth;
            _mapLocationY = _playZoneHeight / 4;
        }
    }

    public static void SetPlayZoneScreen((int Width, int Height) mapSize)
    {
        MapSize = mapSize;
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(_playZoneWidth, _playZoneHeight);
        Console.SetBufferSize(_playZoneWidth, _playZoneHeight);
    }

    public static void SetScreen(int x, int y)
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(x, y);
        Console.SetBufferSize(x, y);
    }

    public static void DrawCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell)
        {
            return;
        }

        var symbol = cell switch
        {
            Empty => " ",
            Player => "I",
            Prize => "@",
            Stop => ".",
            Trap => "%",
            Wall => "#",
            _ => "?" // Error value
        };

        var color = cell switch
        {
            Player => Color.DodgerBlue,
            Prize => Color.FromArgb(12, 216, 0),
            Stop => Color.Yellow,
            Trap => Color.FromArgb(255, 65, 82),
            Wall => Color.White,
            _ => Color.Transparent
        };

        Console.SetCursorPosition(cell.X + _mapLocationX, cell.Y + _mapLocationY);

        Console.Write(symbol.Pastel(color));
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell)
        {
            return;
        }

        Console.SetCursorPosition(cell.X + _mapLocationX, cell.Y + _mapLocationY);

        Console.Write(" ");
    }

    public static void DrawControls(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip)
        {
            return;
        }

        controlsTip.Text = Resources.ControlsTip;

        Console.SetCursorPosition(0, (_playZoneHeight - controlsTip.Height) / 2);

        DrawCentered(LeftSectionWidth, controlsTip.Text);
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score)
        {
            return;
        }

        score.Text = "Score: " + score.ScoreToDraw.ToString().Pastel(Color.FromArgb(12, 216, 0));

        Console.SetCursorPosition(LeftSectionWidth + MapSize.Width, (_playZoneHeight - score.Height) / 2);

        DrawCentered(RightSectionWidth, score.Text);
    }

    public static void DrawCentered(int width, string text)
    {
        // Needed for correct output
        Console.OutputEncoding = Encoding.UTF8;

        var asciiColorCodeRegex = new Regex("\u001B\\[[;\\d]*[ -/]*[@-~]");

        foreach (var line in text.Split('\n'))
        {
            // Getting a line without ASCII color codes to use its length for correct centering
            var colorlessLine = asciiColorCodeRegex.Replace(line, "");

            Console.WriteLine(new string(' ', (width - colorlessLine.Length) / 2) + line);
        }
    }
}