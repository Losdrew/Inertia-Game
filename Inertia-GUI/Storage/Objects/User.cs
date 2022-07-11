namespace GUI.Storage.Objects;

internal class User
{
    public User(string name = "Anonymous")
    {
        Name = name;
    }

    public string Name { get; set; }

    public int PrizeCount { get; set; }

    public int CompletedLevelsCount { get; set; }

    public int GameOverCount { get; set; }

    public DateTime SavedDateTime { get; set; }

    public bool HasResults()
    {
        return !(PrizeCount == 0 && CompletedLevelsCount == 0 && GameOverCount == 0);
    }
}