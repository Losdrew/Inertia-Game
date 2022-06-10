using CommonCodebase.Core;

namespace CommonCodebase.Entities;

public class Empty : CellBase
{
    public Empty(int x, int y) : base(x, y)
    {
        CollisionType = Collision.None;
    }
}