using CommonCodebase.Core;

namespace CommonCodebase.Entities;

public class Player : CellBase
{
    public Player(int x, int y) : base(x, y)
    {
        CollisionType = Collision.None;
    }

    public void ChangePosition(int x, int y)
    {
        ClearOnScreen(); // Clear past position

        (X, Y) = (x, y);
    }
}