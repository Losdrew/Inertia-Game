using CommonCodebase.Core;
using CommonCodebase.Engines;
using GUI.Properties;

namespace GUI.Engines;

[Flags]
internal enum InputType
{
    MovementInput = 1,
    MusicInput = 2,
    PauseInput = 4
}

internal static class InputEngine
{
    public static InputType AllowedInput;
    public static Dictionary<Keys, Music>? MusicControls;
    public static Dictionary<Keys, Direction>? DirectionControls;

    private const Keys PauseKey = Keys.Escape;

    public static void ReadKey(object? sender, KeyEventArgs e)
    {
        if (AllowedInput.HasFlag(InputType.MusicInput))
        {
            CheckForMusicInput(e.KeyCode);
        }

        if (AllowedInput.HasFlag(InputType.PauseInput))
        {
            CheckForPauseInput(e.KeyCode);
        }

        if (AllowedInput.HasFlag(InputType.MovementInput))
        {
            CheckForMovementInput(e.KeyCode);
        }
    }

    private static void CheckForMusicInput(Keys key)
    {
        if (MusicControls is null)
        {
            return;
        }

        if (!MusicControls.ContainsKey(key))
        {
            return;
        }

        switch (MusicControls[key])
        {
            case Music.PauseMusic when !AudioEngine.IsMusicPaused:
                AudioEngine.PauseMusic();
                break;
            case Music.PauseMusic when AudioEngine.IsMusicPaused:
                AudioEngine.ResumeMusic();
                break;
            case Music.SwitchMusic:
                AudioEngine.SwitchMusic();
                break;
        }
    }

    private static void CheckForMovementInput(Keys key)
    {
        if (DirectionControls is null)
        {
            return;
        }

        if (!DirectionControls.ContainsKey(key))
        {
            return;
        }

        MovementEngine.GetInput(DirectionControls[key]);
    }

    private static void CheckForPauseInput(Keys key)
    {
        if (key != PauseKey)
        {
            return;
        }

        var previousInput = AllowedInput;

        AllowedInput = InputType.PauseInput;
        AudioEngine.PauseMusic();

        if (MessageBox.Show(
                Resources.PauseMessageBoxText,
                Resources.PauseMessageBoxCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information) == DialogResult.OK)
        {
            AllowedInput = previousInput;
            AudioEngine.ResumeMusic();
        }
    }
}