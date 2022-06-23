using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace CommonCodebase.Entities;

public class Trap : CellBase
{
    public static Action? GameOver;

    public Trap(int x, int y) : base(x, y)
    {
        CollisionType = Collision.At;
    }

    public override void Action(Map map)
    {
        StopMovement?.Invoke();
        GameOver?.Invoke();

        AudioEngine.PlayAudio("Trap");
    }
}