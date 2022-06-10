using System.Text;
using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using Pastel;

namespace ConsoleApplication.Engines;

public static class GraphicsEngine
{
    public static void SetPlayZoneScreen()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(ControlsTip.Width + Map.Width + Score.Width, Map.Height * 2);
        Console.SetBufferSize(ControlsTip.Width + Map.Width + Score.Width, Map.Height * 2);
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
        if (sender is not CellBase cell) return;

        var symbol = cell switch
        {
            Empty => " ",
            Player => "I",
            Prize => "@",
            Stop => ".",
            Trap => "%",
            Wall => "#",
            _ => "?"
        };

        DrawText(cell.X + ControlsTip.Width,
            cell.Y + (Console.WindowHeight - Map.Height) / 2,
            symbol.Pastel(cell.Color));
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score) return;

        DrawText(score.X,
            score.Y,
            score.Text + score.TotalScore.ToString().Pastel(score.Color));
    }

    public static void UpdateScore(object? sender, EventArgs e)
    {
        if (sender is not Score score) return;

        DrawText(score.X + score.Text.Length,
            score.Y,
            (score.TotalScore + ++score.CurrentScore).ToString().Pastel(score.Color));
    }

    public static void DrawControls(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip) return;

        DrawText(controlsTip.X, controlsTip.Y, controlsTip.Text);
    }

    private static void DrawText(int x, int y, string text)
    {
        SetPosition(x, y);
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write(text);
    }

    private static void SetPosition(int x, int y)
    {
        Console.SetCursorPosition(x, y);
    }

    public static void DrawCentered(int screenWidth, string text)
    {
        foreach (var line in text.Split('\n'))
            Console.WriteLine("{0," + (screenWidth / 2 + line.Length / 2) + "}", line);
    }
}