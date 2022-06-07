using MyGame.Core;

namespace MyGame.Screens;

public class MenuItem
{
    public string Title { get; }

    public ConsoleKey Key { get; }

    public GameState State { get; }

    public MenuItem(string title, ConsoleKey key, GameState state)
    {
        Title = title;
        Key = key;
        State = state;
    }
}

public class MenuItems : List<MenuItem>
{
    private List<MenuItem> Items { get; }

    public MenuItems()
    {
        Items = new List<MenuItem>();
    }

    public void Add(string title, ConsoleKey key, GameState state)
    {
        Items.Add(new MenuItem(title, key, state));
    }

    public List<string> Titles()
    {
        return Items.Select(item => item.Title).ToList();
    }

    public IEnumerable<ConsoleKey> Keys()
    {
        return Items.Select(item => item.Key).ToList();
    }

    public GameState GetState(ConsoleKey key)
    {
        return Items.Find(item => item.Key == key)?.State ?? GameState.Quit;
    }
}