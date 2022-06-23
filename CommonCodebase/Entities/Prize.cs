using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace CommonCodebase.Entities;

public class Prize : CellBase
{
    public static Action? Win;

    public Prize(int x, int y) : base(x, y)
    {
        CollisionType = Collision.At;
    }

    public override void Action(Map map)
    {
        ClearOnMap(map);

        StopMovement?.Invoke();

        AudioEngine.PlayAudio("Prize");

        if (map.PrizeCount == 0)
        {
            Win?.Invoke();
            AudioEngine.PlayAudio("Win");
        }
    }
}