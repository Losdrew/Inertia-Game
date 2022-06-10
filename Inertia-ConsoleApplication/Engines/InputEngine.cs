using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace ConsoleApplication.Engines;

public static class InputEngine
{
    private static readonly Dictionary<ConsoleKey, Direction> DirectionControls = new()
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

    private static readonly Dictionary<ConsoleKey, Music> MusicControls = new()
    {
        { ConsoleKey.R, Music.PauseMusic },
        { ConsoleKey.F, Music.SwitchMusic },
    };

    public static Enum GetInput<T>()
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

            switch(typeof(T))
            {
                case { } direction when direction == typeof(Direction):
                    return DirectionControls[key];

                case { } direction when direction == typeof(ConsoleKey):
                    return key;

                default: continue;
            };
        }
    }
}