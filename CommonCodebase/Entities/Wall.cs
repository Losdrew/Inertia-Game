using System.Drawing;
using CommonCodebase.Core;
using CommonCodebase.Engines;

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
        MovementEngine.SetMovement(false);
        AudioEngine.PlayAudio("Wall");
    }
}