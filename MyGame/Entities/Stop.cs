namespace MyGame.Entities;

public class Stop : Cell
{
    public Stop(int x, int y) : base(x, y)
    {
        CellType = '.';
        Color = ConsoleColor.Yellow;
    }
}