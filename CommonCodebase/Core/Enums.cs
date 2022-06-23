namespace CommonCodebase.Core
{
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
}

namespace ConsoleApplication
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

namespace GUI.Engines
{
    [Flags]
    public enum InputType
    {
        MovementInput,
        MusicInput
    }
}