using MyGame.Core;

namespace MyGame.Entities;

public class Cell : VisualObject
{
    protected char CellType { get; init; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        CellType = ' ';
    }

    public override void Draw()
    {
        Console.SetCursorPosition(
            Map.MapLeftMargin + X,
            (Console.WindowHeight - Map.MapHeight) / 2 + Y);

        ApplyColor();

        Console.Write(CellType);

        ResetColor();
    }

    public void Clear()
    {
        Console.SetCursorPosition(
            Map.MapLeftMargin + X,
            (Console.WindowHeight - Map.MapHeight) / 2 + Y);

        Console.Write(' ');
    }
}