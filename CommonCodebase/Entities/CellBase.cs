using CommonCodebase.Core;

namespace CommonCodebase.Entities;

public abstract class CellBase : VisualObject
{
    public Collision CollisionType { get; protected init; }

    protected CellBase(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static event EventHandler? DrawCell;

    public override void Draw()
    {
        DrawCell?.Invoke(this, EventArgs.Empty);
    }

    protected static void Draw(object? sender, EventArgs e)
    {
        DrawCell?.Invoke(sender, e);
    }

    public virtual void Action(Map map) { }

    protected void ClearOnMap(Map map)
    {
        map[X, Y] = new Empty(X, Y);
    }
}