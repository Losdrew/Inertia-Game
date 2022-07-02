using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace GUI.Engines;

[Flags]
internal enum InputType
{
    MovementInput = 1,
    MusicInput = 2
}

internal static class InputEngine
{
    public static InputType AllowedInput;
    public static Dictionary<Keys, Music>? MusicControls;
    public static Dictionary<Keys, Direction>? DirectionControls;

    public static void ReadKey(object? sender, KeyEventArgs e)
    {
        if (AllowedInput.HasFlag(InputType.MusicInput))
        {
            CheckForMusicInput(e.KeyCode);
        }

        if (AllowedInput.HasFlag(InputType.MovementInput))
        {
            CheckForMovementInput(e.KeyCode);
        }
    }

    private static void CheckForMusicInput(Keys key)
    {
        if (MusicControls == null)
        {
            return;
        }

        if (MusicControls.ContainsKey(key))
        {
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

    private static void CheckForMovementInput(Keys key)
    {
        if (DirectionControls is null)
        {
            return;
        }

        if (DirectionControls.ContainsKey(key))
        {
            MovementEngine.GetInput(DirectionControls[key]);
        }
    }
}