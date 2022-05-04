namespace MyGame.Core;

public abstract class VisualObject
{
    public int X { get; set; }

    public int Y { get; set; }

    protected ConsoleColor Color { get; init; }

    public abstract void Draw();

    protected void ApplyColor()
    {
        Console.ForegroundColor = Color;
    }

    protected void ResetColor()
    {
        Console.ResetColor();
    }
}