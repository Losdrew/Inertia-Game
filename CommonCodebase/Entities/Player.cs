using System.Drawing;
using CommonCodebase.Core;

namespace CommonCodebase.Entities;

public class Player : CellBase
{
    // Time between frames (used for movement)
    private const int FrameMs = 85;

    public Player(int x, int y) : base(x, y)
    {
        CollisionType = Collision.None;
        Color = Color.DodgerBlue;
    }

    public void ChangePosition(int x, int y)
    {
        ClearOnScreen();
        (X, Y) = (x, y);
        Draw();

        // Artificial lag for smooth movement
        Thread.Sleep(FrameMs);
    }
}