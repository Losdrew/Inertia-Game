using CommonCodebase.Core;
using CommonCodebase.Engines;
using System.Drawing;

namespace CommonCodebase.Entities;

public class Stop : CellBase
{
    public Stop(int x, int y) : base(x, y)
    {
        CollisionType = Collision.At;
        Color = Color.Yellow;
    }

    public override void Action(Map map)
    {
        ClearOnMap(map);
        AudioEngine.PlayAudio("Stop");
        MovementEngine.MovementAvailable = false;
    }
}