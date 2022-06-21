using CommonCodebase.Core;
using CommonCodebase.Engines;
using System.Drawing;

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
        AudioEngine.PlayAudio("Prize");
        MovementEngine.MovementAvailable = false;

        if (map.PrizeCount == 0)
        {
            AudioEngine.PlayAudio("Win");
            MovementEngine.SetWin();
        }
    }
}