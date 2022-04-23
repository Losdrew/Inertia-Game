namespace MyGame
{
    class Wall : Cell
    {
        public Wall(int x, int y) : base(x, y)
        {
            CellType = '#';
            Color = ConsoleColor.White;
        }
    }
}
