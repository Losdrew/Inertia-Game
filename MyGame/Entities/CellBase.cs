using MyGame.Core;
using Pastel;

namespace MyGame.Entities;

public abstract class CellBase : VisualObject
{
    public Collision CollisionType { get; protected init; }

    protected string Symbol { get; init; }

    protected CellBase(int x, int y)
    {
        X = x;
        Y = y;
        Symbol = "?"; // Default unused value
    }

    public override void Draw()
    {
        SetPosition();
        Console.Write(Symbol.Pastel(Color));
    }

    public virtual void Action(Map map) { }

    protected void SetPosition()
    {
        Console.SetCursorPosition(
            Miscellaneous.ControlsTip.Width + X, 
            (Console.WindowHeight - Map.Height) / 2 + Y);
    }

    protected void ClearOnMap(Map map)
    {
        map[X, Y] = new Empty(X, Y);
    }
}