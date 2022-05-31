using MyGame.Core;

namespace MyGame.Engines;

public static class InputEngine
{
    public static event AudioEngine.MusicHandler? PauseMusic;
    public static event AudioEngine.MusicHandler? SwitchMusic;

    public static ConsoleKey GetInput(IEnumerable<ConsoleKey> enumerable)
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;

            CheckForMusicControls(key);

            if (enumerable.Contains(key))
                return key;
        }
    }

    private static void CheckForMusicControls(ConsoleKey key)
    {
        switch (key)
        {
            case (ConsoleKey)MusicControls.PauseMusic:
                PauseMusic?.Invoke();
                break;

            case (ConsoleKey)MusicControls.SwitchMusic:
                SwitchMusic?.Invoke();
                break;
        }
    }
}