using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace GUI.Engines;

public static class MovementEngine
{
    public static readonly MovementEngineBase Movement = new();

    public static void Move()
    {
        if (Movement.IsWin)
        {
            Movement.Win?.Invoke();
        }

        if (Movement.IsGameOver)
        {
            Movement.GameOver?.Invoke();
        }

        Movement.Move();
    }

    public static void StopMovement()
    {
        Movement.StopMovement();
        AnimationEngine.SetPlayerGifAnimation(false);
    }

    public static void GetInput(Direction direction)
    {
        // Input must not be accepted while movement is in progress
        if (Movement.IsMovementOngoing)
        {
            return;
        }

        Movement.IsMovementOngoing = true;
        Movement.CurrentDirection = direction;
        AnimationEngine.SetPlayerGifAnimation(true);

        Move();
    }
}