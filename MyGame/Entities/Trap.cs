namespace MyGame.Entities;

public class Trap : Cell
{
    public Trap(int x, int y) : base(x, y)
    {
        CellType = '%';
        Color = ConsoleColor.Red;
    }
}