namespace ConsoleApplication.Screens;

internal class MenuItem
{
    public MenuItem(string title, ConsoleKey key, GameState state)
    {
        Title = title;
        Key = key;
        State = state;
    }

    public string Title { get; }

    public ConsoleKey Key { get; }

    public GameState State { get; }
}