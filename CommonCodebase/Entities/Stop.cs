using System.Drawing;
using CommonCodebase.Core;
using CommonCodebase.Engines;

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
        MovementEngine.SetMovement(false);
        AudioEngine.PlayAudio("Stop");
    }
}