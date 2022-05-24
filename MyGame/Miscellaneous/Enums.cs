namespace MyGame.Miscellaneous;

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