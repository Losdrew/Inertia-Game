using CommonCodebase.Core;

namespace GUI.Engines;

public static class MovementEngine
{
    private static Map? _map;

    private static bool _isMovementOngoing;

    private static Direction _currentDirection;

    public static void GetCurrentMap(Map currentMap)
    {
        _map = currentMap;
    }

    public static void Move()
    {
        if (!_isMovementOngoing || _map is null)
        {
            return;
        }

        var (x, y) = Map.GetDestination(_map.Player.X, _map.Player.Y, _currentDirection);

        if (_map[x, y].CollisionType is Collision.At or Collision.None)
        {
            _map.Player.ChangePosition(x, y);
            AnimationEngine.StartAnimation(_map.Player);
        }

        _map[x, y].Action(_map);
    }

    public static void StopMovement()
    {
        _isMovementOngoing = false;
        AnimationEngine.SetPlayerGifAnimation(false);
    }

    public static void GetInput(Direction direction)
    {
        // Input must not be accepted while movement is in progress
        if (_isMovementOngoing)
        {
            return;
        }

        _isMovementOngoing = true;
        _currentDirection = direction;
        AnimationEngine.SetPlayerGifAnimation(true);

        Move();
    }
}