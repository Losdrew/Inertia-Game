using CommonCodebase.Core;

namespace CommonCodebase.Entities;

public abstract class CellBase : VisualObject
{
    protected CellBase(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; protected set; }

    public int Y { get; protected set; }

    public Collision CollisionType { get; protected init; }

    public static event EventHandler? DrawCell;

    public override void Draw()
    {
        DrawCell?.Invoke(this, EventArgs.Empty);
    }

    public virtual void Action(Map map)
    {
    }

    protected void ClearOnScreen()
    {
        DrawCell?.Invoke(new Empty(X, Y), EventArgs.Empty);
    }

    protected void ClearOnMap(Map map)
    {
        map[X, Y] = new Empty(X, Y);
    }
}