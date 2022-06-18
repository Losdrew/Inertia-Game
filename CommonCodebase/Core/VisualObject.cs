using System.Drawing;

namespace CommonCodebase.Core;

public abstract class VisualObject
{
    public Color Color { get; protected init; }

    public abstract void Draw();
}