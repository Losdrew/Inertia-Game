using CommonCodebase.Core;
using CommonCodebase.Engines;
using System.Drawing;

namespace CommonCodebase.Entities;

public class Trap : CellBase
{
    public Trap(int x, int y) : base(x, y)
    {
        CollisionType = Collision.At;
        Color = Color.FromArgb(255, 65, 82);
    }

    public override void Action(Map map)
    {
        MovementEngine.SetGameOver();
        AudioEngine.PlayAudio("Trap");
        MovementEngine.MovementAvailable = false;
    }
}