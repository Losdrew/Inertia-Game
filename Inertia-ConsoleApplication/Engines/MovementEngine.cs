using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace ConsoleApplication.Engines;

internal static class MovementEngine
{
    public static readonly MovementEngineBase Movement = new();

    public static GameState Start()
    {
        while (true)
        {
            Movement.CurrentDirection = (Direction)InputEngine.GetInput();

            Movement.IsMovementOngoing = true;

            while (Movement.IsMovementOngoing)
            {
                Movement.Move();
            }

            if (Movement.IsWin)
            {
                return GameState.Win;
            }

            if (Movement.IsGameOver)
            {
                return GameState.GameOver;
            }
        }
    }
}