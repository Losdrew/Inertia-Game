using System.Drawing;

namespace MyGame.Entities;

public class Trap : Cell
{
    public Trap(int x, int y) : base(x, y)
    {
        CellType = "%";
        CollisionType = Collision.GameOver;
        Color = Color.FromArgb(255, 65, 82);
    }
}