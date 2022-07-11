using CommonCodebase.Core;
using CommonCodebase.Entities;

namespace CommonCodebase.Engines;

public class MovementEngineBase
{
    public Direction CurrentDirection;

    public bool IsMovementOngoing, IsWin, IsGameOver;

    public Action? Win;
    public Action? GameOver;
    public Action<Player>? StartAnimation;
    
    private Map? _map;

    public void GetCurrentMap(Map currentMap)
    {
        _map = currentMap;

        // Update win/loss values when starting on a new map 
        IsWin = false;
        IsGameOver = false;
    }

    public void Move()
    {
        if (!IsMovementOngoing || _map is null || _map.Player is null)
        {
            return;
        }

        var (x, y) = Map.GetDestination(_map.Player.X, _map.Player.Y, CurrentDirection);

        if (_map[x, y]?.CollisionType is Collision.At or Collision.None)
        {
            _map.Player.ChangePosition(x, y);
            StartAnimation?.Invoke(_map.Player);
        }

        _map[x, y]?.Action(_map);
    }

    public void StopMovement()
    {
        IsMovementOngoing = false;
    }

    public void SetWin()
    {
        IsWin = true;
    }

    public void SetGameOver()
    {
        IsGameOver = true;
    }
}