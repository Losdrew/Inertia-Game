using CommonCodebase.Core;

namespace CommonCodebase.Engines;

public static class MovementEngine
{
    private static bool _isMoving, _isWin, _isGameOver;

    public static InputHandler<Direction>? GetMovementInput;

    public static GameState Start(Map map)
    {
        // Refreshing values because variables are static
        _isWin = false;
        _isGameOver = false;

        while (true)
        {
            _isMoving = true;

            var direction = (Direction)GetMovementInput?.Invoke()!;

            while (_isMoving)
                Move(map, direction);

            if (_isWin)
                return GameState.Win;

            if (_isGameOver)
                return GameState.GameOver;
        }
    }

    public static void SetMovement(bool value)
    {
        _isMoving = value;
    }

    public static void SetWin(bool value)
    {
        _isWin = value;
    }

    public static void SetGameOver(bool value)
    {
        _isGameOver = value;
    }

    private static void Move(Map map, Direction direction)
    {
        var (x, y) = Map.GetDestination(map.Player.X, map.Player.Y, direction);

        if (map[x, y].CollisionType is Collision.At or Collision.None)
            map.Player.ChangePosition(x, y);

        map[x, y].Action(map);
    }
}