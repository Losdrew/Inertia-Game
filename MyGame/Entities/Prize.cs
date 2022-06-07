using System.Drawing;
using MyGame.Core;
using MyGame.Engines;

namespace MyGame.Entities;

public class Prize : CellBase
{
    public Prize(int x, int y) : base(x, y)
    {
        Symbol = "@";
        CollisionType = Collision.At;
        Color = Color.FromArgb(12, 216, 0);
    }

    public override void Action(Map map)
    {
        ClearOnMap(map);
        MovementEngine.SetMovement(false);
        AudioEngine.PlayAudio("Prize");

        if (map.PrizeCount == 0)
        {
            MovementEngine.SetWin(true);
            AudioEngine.PlayAudio("Win");
        }
    }
}