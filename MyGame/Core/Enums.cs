namespace MyGame.Core
{
    public enum GameState
    {
        InMenu,
        Start,
        Play,
        Win,
        GameOver,
        Restart,
        Continue,
        CreateNew,
        Quit
    }
}

namespace MyGame.Entities
{
    public enum Collision
    {
        None,
        At,
        Before
    }
}

namespace MyGame.Core
{
    public enum Direction
    {
        Up = ConsoleKey.W,
        Down = ConsoleKey.X,
        Left = ConsoleKey.A,
        Right = ConsoleKey.D,
        LeftUp = ConsoleKey.Q,
        RightUp = ConsoleKey.E,
        LeftDown = ConsoleKey.Z,
        RightDown = ConsoleKey.C
    }

    public enum MusicControls
    {
        PauseMusic = ConsoleKey.R,
        SwitchMusic = ConsoleKey.F
    }
}