using MyGame.Core;
using Pastel;

namespace MyGame.Entities;

public class Cell : VisualObject
{
    public string CellType { get; protected init; }
     
    public Collision CollisionType { get; protected init; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        CellType = " ";
        CollisionType = Collision.None;
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
            Miscellaneous.ControlsTip.Width + X, 
            (Console.WindowHeight - Map.Height) / 2 + Y);
    }
}