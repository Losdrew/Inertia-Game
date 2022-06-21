using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace Engines;

public static class InputEngine
{
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

            if (MusicControls.ContainsKey(key))
            {
                switch (MusicControls[key])
                {
                    case Music.PauseMusic:
                        AudioEngine.PauseMusic();
                        continue;

                    case Music.SwitchMusic:
                        AudioEngine.SwitchMusic();
                        continue;
                }
            }

            if (DirectionControls.ContainsKey(key))
            {
                return DirectionControls[key];
            }

            if (ScreenControls.ContainsKey(key))
            {
                return ScreenControls[key];
            }
        }
    }
}