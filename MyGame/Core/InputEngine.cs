using MyGame.Miscellaneous;

namespace MyGame.Core;

public static class InputEngine
{
    public static event AudioEngine.MusicHandler? PauseMusic;
    public static event AudioEngine.MusicHandler? SwitchMusic;

    public static ConsoleKey GetInput(IEnumerable<ConsoleKey> enumerable)
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key is (ConsoleKey)MusicControls.PauseMusic)
                PauseMusic?.Invoke();

            if (key is (ConsoleKey)MusicControls.SwitchMusic)
                SwitchMusic?.Invoke();

            if (enumerable.Contains(key))
                return key;
        }
    }
}