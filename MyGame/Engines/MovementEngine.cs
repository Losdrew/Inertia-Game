using MyGame.Core;
using MyGame.Entities;

namespace MyGame.Engines;

public static class MovementEngine
{
    private static bool IsMoving, IsWin, IsGameOver;

    public static GameState Start(Map map)
    {
        // Refreshing values because variables are static
        IsWin = false;
        IsGameOver = false;

        while (true)
        {
            var key = InputEngine.GetInput(Enum.GetValues<Direction>().Cast<ConsoleKey>());

            IsMoving = true;

            while (IsMoving)
                Move(map, (Direction)key);

            if (IsWin)
                return GameState.Win;

            if (IsGameOver)
                return GameState.GameOver;
        }
    }

    public static void SetMovement(bool value)
    {
        IsMoving = value;
    }

    public static void SetWin(bool value)
    {
        IsWin = value;
    }
    public static void SetGameOver(bool value)
    {
        IsGameOver = value;
    }

    private static void Move(Map map, Direction direction)
    {
        var (x, y) = Map.GetDestination(map.Player.X, map.Player.Y, direction);

        if (map[x, y].CollisionType is Collision.At or Collision.None)
            map.Player.ChangePosition(x, y);

        map[x, y].Action(map);
    }
}