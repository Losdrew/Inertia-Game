using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
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

    private static readonly int PlayZoneScreenWidth = LeftSectionWidth + Map.Size.Width + RightSectionWidth;
    private static readonly int PlayZoneScreenHeight = Map.Size.Height * 2;

    private static readonly int MapLocationX = LeftSectionWidth;
    private static readonly int MapLocationY = PlayZoneScreenHeight / 4;

    public static void SetPlayZoneScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(PlayZoneScreenWidth, PlayZoneScreenHeight);
        Console.SetBufferSize(PlayZoneScreenWidth, PlayZoneScreenHeight);
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

        SetCursorPosition(cell.X + MapLocationX, cell.Y + MapLocationY);

        DrawText(symbol.Pastel(color));
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell)
        {
            return;
        }

        SetCursorPosition(cell.X + MapLocationX, cell.Y + MapLocationY);

        DrawText(" ");
    }

    public static void DrawControls(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip)
        {
            return;
        }

        controlsTip.Text = Resources.ControlsTip;

        SetCursorPosition(0, Map.Size.Height - ControlsTip.Height / 2);

        DrawCentered(LeftSectionWidth, controlsTip.Text);
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score)
        {
            return;
        }

        var text = score.Text + score.ScoreToDraw.ToString().Pastel(Color.FromArgb(12, 216, 0));

        SetCursorPosition(LeftSectionWidth + Map.Size.Width, Map.Size.Height - Score.Height / 2);

        DrawCentered(RightSectionWidth, text);
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

    private static void DrawText(string text)
    {
        Console.Write(text);
    }

    private static void SetCursorPosition(int x, int y)
    {
        Console.SetCursorPosition(x, y);
    }
}