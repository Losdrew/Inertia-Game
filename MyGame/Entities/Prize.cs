using System.Drawing;

namespace MyGame.Entities;

public class Prize : Cell
{
    public Prize(int x, int y) : base(x, y)
    {
        CellType = "@";
        Color = Color.FromArgb(12, 216, 0);
    }
}