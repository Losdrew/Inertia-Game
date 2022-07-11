namespace ConsoleApplication.Screens;

internal class MenuItem
{
    public readonly string Title;
    public readonly ConsoleKey Key;
    public readonly GameState State;

    public MenuItem(string title, ConsoleKey key, GameState state)
    {
        Title = title;
        Key = key;
        State = state;
    }
}