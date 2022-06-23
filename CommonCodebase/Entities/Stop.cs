using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace CommonCodebase.Entities;

public class Stop : CellBase
{
    public Stop(int x, int y) : base(x, y)
    {
        CollisionType = Collision.At;
    }

    public override void Action(Map map)
    {
        ClearOnMap(map);

        StopMovement?.Invoke();

        AudioEngine.PlayAudio("Stop");
    }
}