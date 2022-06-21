using CommonCodebase.Core;

namespace CommonCodebase.Engines;

public static class MovementEngine
{
    // Time between frames (used for movement animation)
    public const int FrameMs = 85;

    public static Action? Win;
    public static Action? GameOver;

    public static Action? StartMovement;
    public static Action? StopMovement;

    private static Direction _currentDirection;

    public static bool MovementAvailable { get; set; }

    private static Map? Map { get; set; }

    public static void Start(Map currentMap)
    {
        Map = currentMap;
    }

    public static void Move(object? sender, EventArgs e)
    {
        if (Map is null)
        {
            return;
        }

        var (x, y) = Map.GetDestination(Map.Player.X, Map.Player.Y, _currentDirection);

        if (Map[x, y].CollisionType is Collision.At or Collision.None)
        {
            Map.Player.ChangePosition(x, y);
        }

        Map[x, y].Action(Map);

        if (!MovementAvailable)
        {
            StopMovement?.Invoke();
        }
    }

    public static void SetWin()
    {
        Win?.Invoke();
    }

    public static void SetGameOver()
    {
        GameOver?.Invoke();
    }

    public static void GetInput(Direction direction)
    {
        _currentDirection = direction;
        MovementAvailable = true;
        StartMovement?.Invoke();
    }
}