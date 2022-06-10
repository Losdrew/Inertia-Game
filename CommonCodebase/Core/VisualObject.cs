using System.Drawing;

namespace CommonCodebase.Core;

public abstract class VisualObject
{
    public int X { get; protected set; }

    public int Y { get; protected set; }

    public Color Color { get; protected init; }

    public abstract void Draw();
}