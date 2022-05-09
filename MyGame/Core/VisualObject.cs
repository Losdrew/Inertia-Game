namespace MyGame.Core;

public abstract class VisualObject
{
    public int X { get; set; }

    public int Y { get; set; }

    protected System.Drawing.Color Color { get; init; }

    public abstract void Draw();
}