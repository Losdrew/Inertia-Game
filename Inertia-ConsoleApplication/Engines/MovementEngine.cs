using CommonCodebase.Core;

namespace ConsoleApplication.Engines;

public static class MovementEngine
{
    private static bool _movementAvailable, _isWin, _isGameOver;

    public static GameState Start(Map map)
    {
        // Refreshing values because variables are static
        _isWin = false;
        _isGameOver = false;

        while (true)
        {
            _movementAvailable = true;

            var direction = (Direction)InputEngine.GetInput();

            while (_movementAvailable)
            {
                Move(map, direction);
            }

            if (_isWin)
            {
                return GameState.Win;
            }

            if (_isGameOver)
            {
                return GameState.GameOver;
            }
        }
    }

    public static void StopMovement()
    {
        _movementAvailable = false;
    }

    public static void SetWin()
    {
        _isWin = true;
    }

    public static void SetGameOver()
    {
        _isGameOver = true;
    }

    private static void Move(Map map, Direction direction)
    {
        var (x, y) = Map.GetDestination(map.Player.X, map.Player.Y, direction);

        if (map[x, y].CollisionType is Collision.At or Collision.None)
        {
            map.Player.ChangePosition(x, y);
        }

        map[x, y].Action(map);
    }
}