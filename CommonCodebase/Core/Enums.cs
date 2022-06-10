namespace CommonCodebase.Core;

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

public enum Collision
{
    None,
    At,
    Before
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    LeftUp,
    RightUp,
    LeftDown,
    RightDown
}

public enum Music
{
    PauseMusic,
    SwitchMusic
}