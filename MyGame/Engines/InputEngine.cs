using MyGame.Core;

namespace MyGame.Engines;

public static class InputEngine
{
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
                AudioEngine.PauseMusic();
                break;

            case (ConsoleKey)MusicControls.SwitchMusic:
                AudioEngine.SwitchMusic();
                break;
        }
    }
}