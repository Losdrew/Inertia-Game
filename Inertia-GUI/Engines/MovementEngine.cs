using CommonCodebase.Core;

namespace CommonCodebase.Engines;

public static class MovementEngine
{
    public static Action? Win;
    public static Action? GameOver;

    private static Action? _startMovement;

    private static Direction _currentDirection;

    private static Map? Map { get; set; }

    public static bool MovementAvailable { get; set; }

    public static void Start(Map currentMap)
    {
        Map = currentMap;

        _startMovement += Move;
    }

    private static void Move()
    {
        if (Map is null)
        {
            return;
        }

        while (MovementAvailable)
        {
            var (x, y) = Map.GetDestination(Map.Player.X, Map.Player.Y, _currentDirection);

            if (Map[x, y].CollisionType is Collision.At or Collision.None)
            {
                Map.Player.ChangePosition(x, y);
            }

            Map[x, y].Action(Map);
        }
    }

    public static void SetMovementUnavailable()
    {
        MovementAvailable = false;
    }

    public static void GetInput(Direction direction)
    {
        if (MovementAvailable)
        {
            return;
        }

        _currentDirection = direction;
        MovementAvailable = true;
        _startMovement?.Invoke();
    }
}