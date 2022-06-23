using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace CommonCodebase.Entities;

public class Wall : CellBase
{
    public Wall(int x, int y) : base(x, y)
    {
        CollisionType = Collision.Before;
    }

    public override void Action(Map map)
    {
        StopMovement?.Invoke();

        AudioEngine.PlayAudio("Wall");
    }
}