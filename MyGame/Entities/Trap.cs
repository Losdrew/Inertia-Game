using System.Drawing;
using MyGame.Core;
using MyGame.Engines;

namespace MyGame.Entities;

public class Trap : CellBase
{
    public Trap(int x, int y) : base(x, y)
    {
        Symbol = "%";
        CollisionType = Collision.At;
        Color = Color.FromArgb(255, 65, 82);
    }

    public override void Action(Map map)
    {
        MovementEngine.SetMovement(false);
        MovementEngine.SetGameOver(true);
        AudioEngine.PlayAudio("Trap");
    }
}