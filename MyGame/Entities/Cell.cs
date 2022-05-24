using MyGame.Core;
using MyGame.Miscellaneous;
using Pastel;

namespace MyGame.Entities;

public class Cell : VisualObject
{
    protected string CellType { get; init; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        CellType = " ";
    }

    public override void Draw()
    {
        SetPosition();
        Console.Write(CellType.Pastel(Color));
    }

    public void Clear()
    {
        SetPosition();
        Console.Write(' ');
    }

    private void SetPosition()
    {
        Console.SetCursorPosition(
            ControlsTip.Width + X, 
            (Console.WindowHeight - Map.Height) / 2 + Y);
    }
}