using CommonCodebase.Core;
using System.Drawing;

namespace CommonCodebase.Entities;

public class Player : CellBase
{
    public Player(int x, int y) : base(x, y)
    {
        CollisionType = Collision.None;
        Color = Color.DodgerBlue;
    }

    public static Action? StartMovementAnimation;

    public void ChangePosition(int x, int y)
    {
        ClearOnScreen(); // Clear past position
        (X, Y) = (x, y);
        ClearOnScreen(); // Clear current position
        Draw();

        StartMovementAnimation?.Invoke();
    }
}