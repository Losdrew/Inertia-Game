namespace MyGame.Entities;

public class Prize : Cell
{
    public Prize(int x, int y) : base(x, y)
    {
        CellType = '@';
        Color = ConsoleColor.Green;
    }
}