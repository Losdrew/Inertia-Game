using System.Drawing;
using MyGame.Core;
using MyGame.Engines;

namespace MyGame.Entities;

public class Wall : CellBase
{
    public Wall(int x, int y) : base(x, y)
    {
        Symbol = "#";
        CollisionType = Collision.Before;
        Color = Color.White;
    }

    public override void Action(Map map)
    {
        MovementEngine.SetMovement(false);
        AudioEngine.PlayAudio("Wall");
    }
}