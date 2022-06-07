using System.Drawing;

namespace MyGame.Entities;

public class Player : CellBase
{
    // Time between frames (used for movement)
    private const int FrameMs = 85;

    public Player(int x, int y) : base(x, y)
    {
        Symbol = "I";
        CollisionType = Collision.None;
        Color = Color.DodgerBlue;
    }

    public void ChangePosition(int x, int y)
    {
        Clear();
        (X, Y) = (x, y);
        Draw();

        // Artificial lag for smooth movement
        Thread.Sleep(FrameMs);
    }

    private void Clear()
    {
        SetPosition();
        Console.Write(' ');
    }
}