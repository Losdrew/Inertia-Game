using System.Drawing;
using MyGame.Core;
using MyGame.Engines;

namespace MyGame.Entities;

public class Stop : CellBase
{
    public Stop(int x, int y) : base(x, y)
    {
        Symbol = ".";
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