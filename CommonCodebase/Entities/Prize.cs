using System.Drawing;
using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace CommonCodebase.Entities;

public class Prize : CellBase
{
    public Prize(int x, int y) : base(x, y)
    {
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