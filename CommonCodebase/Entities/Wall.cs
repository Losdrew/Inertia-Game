using CommonCodebase.Core;
using CommonCodebase.Engines;
using System.Drawing;

namespace CommonCodebase.Entities;

public class Wall : CellBase
{
    public Wall(int x, int y) : base(x, y)
    {
        CollisionType = Collision.Before;
        Color = Color.White;
    }

    public override void Action(Map map)
    {
        AudioEngine.PlayAudio("Wall");
        MovementEngine.MovementAvailable = false;
    }
}