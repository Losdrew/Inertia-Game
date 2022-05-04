namespace MyGame.Entities;

public class Player : Cell
{
    public Player(int x, int y) : base(x, y)
    {
        CellType = 'I';
        Color = ConsoleColor.DarkCyan;
    }
}