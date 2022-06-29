using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace ConsoleApplication.Engines;

[Flags]
internal enum InputType
{
    MovementInput = 1,
    MusicInput = 2,
    ScreenInput = 4
}

internal static class InputEngine
{
    public static InputType AllowedInput;

    public static readonly Dictionary<ConsoleKey, GameState> ScreenControls;
    private static readonly Dictionary<ConsoleKey, Music> MusicControls;
    private static readonly Dictionary<ConsoleKey, Direction> DirectionControls;

    static InputEngine()
    {
        ScreenControls = new Dictionary<ConsoleKey, GameState>();

        MusicControls = new Dictionary<ConsoleKey, Music>
        {
            { ConsoleKey.R, Music.PauseMusic },
            { ConsoleKey.F, Music.SwitchMusic }
        };

        DirectionControls = new Dictionary<ConsoleKey, Direction>
        {
            { ConsoleKey.W, Direction.Up },
            { ConsoleKey.X, Direction.Down },
            { ConsoleKey.A, Direction.Left },
            { ConsoleKey.D, Direction.Right },
            { ConsoleKey.Q, Direction.LeftUp },
            { ConsoleKey.E, Direction.RightUp },
            { ConsoleKey.Z, Direction.LeftDown },
            { ConsoleKey.C, Direction.RightDown }
        };
    }

    public static Enum GetInput()
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (AllowedInput.HasFlag(InputType.MusicInput))
            {
                CheckForMusicInput(key);
            }

            if (AllowedInput.HasFlag(InputType.MovementInput))
            {
                if (DirectionControls.ContainsKey(key))
                {
                    return DirectionControls[key];
                }
            }

            if (AllowedInput.HasFlag(InputType.ScreenInput))
            {
                if (ScreenControls.ContainsKey(key))
                {
                    return ScreenControls[key];
                }
            }
        }
    }

    private static void CheckForMusicInput(ConsoleKey key)
    {
        if (!MusicControls.ContainsKey(key))
        {
            return;
        }

        switch (MusicControls[key])
        {
            case Music.PauseMusic:
                AudioEngine.PauseMusic();
                break;
            case Music.SwitchMusic:
                AudioEngine.SwitchMusic();
                break;
        }
    }
}