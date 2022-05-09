using System.Drawing;

namespace MyGame.Entities;

public class Trap : Cell
{
    public Trap(int x, int y) : base(x, y)
    {
        CellType = "%";
        Color = Color.FromArgb(255, 65, 82);
    }
}