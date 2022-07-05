using CommonCodebase.Core;

namespace GUI.Storage.Objects;

internal class Options
{
    public (int Width, int Height) MapSize { get; set; }

    public Dictionary<Direction, Keys>? DirectionControls { get; set; }

    public Dictionary<Music, Keys>? MusicControls { get; set; }

    public string? Language { get; set; }

    public Options()
    {
        MapSize = (20, 10);
        DirectionControls = new Dictionary<Direction, Keys>
        {
            { Direction.LeftUp, Keys.Q },
            { Direction.Up, Keys.W },
            { Direction.RightUp, Keys.E },
            { Direction.Left, Keys.A },
            { Direction.Right, Keys.D },
            { Direction.LeftDown, Keys.Z },
            { Direction.Down, Keys.X },
            { Direction.RightDown, Keys.C }
        };
        MusicControls = new Dictionary<Music, Keys>
        {
            { Music.PauseMusic, Keys.R },
            { Music.SwitchMusic, Keys.F },
        };
        Language = "en-US";
    }
}