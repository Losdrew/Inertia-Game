namespace MyGame
{
    class Prize : Cell
    {
        public Prize(int x, int y) : base(x, y)
        {
            CellType = '@';
            Color = ConsoleColor.Green;
            MoveType = MoveTypes.StopAt;
        }
    }
}
