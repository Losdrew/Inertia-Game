namespace MyGame.Entities;

public class Empty : CellBase
{
    public Empty(int x, int y) : base(x, y)
    {
        Symbol = " ";
        CollisionType = Collision.None;
    }
}