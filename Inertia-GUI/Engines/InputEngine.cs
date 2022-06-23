using CommonCodebase.Core;
using CommonCodebase.Engines;

namespace GUI.Engines;

public static class InputEngine
{
    private static readonly Dictionary<Keys, Music> MusicControls;
    private static readonly Dictionary<Keys, Direction> DirectionControls;

    public static InputType AllowedInput { get; set; }

    static InputEngine()
    {
        MusicControls = new Dictionary<Keys, Music>
        {
            { Keys.R, Music.PauseMusic },
            { Keys.F, Music.SwitchMusic }
        };

        DirectionControls = new Dictionary<Keys, Direction>
        {
            { Keys.W, Direction.Up },
            { Keys.X, Direction.Down },
            { Keys.A, Direction.Left },
            { Keys.D, Direction.Right },
            { Keys.Q, Direction.LeftUp },
            { Keys.E, Direction.RightUp },
            { Keys.Z, Direction.LeftDown },
            { Keys.C, Direction.RightDown }
        };
    }

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

    private static void CheckForMovementInput(Keys key)
    {
        if (DirectionControls.ContainsKey(key))
        {
            MovementEngine.GetInput(DirectionControls[key]);
        }
    }
}