namespace MyGame
{
    public enum CellTypes
    {
        None = ' ',
        Player = 'I',
        Prize = '@',
        Stop = '.',
        Wall = '#',
        Trap = '%'
    }

    public enum CellColors
    {
        Player = ConsoleColor.DarkCyan,
        Prize = ConsoleColor.Green,
        Stop = ConsoleColor.Yellow,
        Wall = ConsoleColor.White,
        Trap = ConsoleColor.Red
    }

    public struct Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public CellTypes CellType { get; set; }

        public ConsoleColor Color { get; set; }

        public Cell(int x, int y, CellTypes cellType)
        {
            X = x;
            Y = y;
            CellType = cellType;

            Color = CellType switch
            {
                CellTypes.Player => (ConsoleColor)CellColors.Player,
                CellTypes.Prize => (ConsoleColor)CellColors.Prize,
                CellTypes.Stop => (ConsoleColor)CellColors.Stop,
                CellTypes.Wall => (ConsoleColor)CellColors.Wall,
                CellTypes.Trap => (ConsoleColor)CellColors.Trap,
                _ => 0
            };
        }

        public Cell(Cell cell) : this(cell.X, cell.Y, cell.CellType) { }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write((char)CellType);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            CellType = 0;
            Console.Write(" ");
        }
    }
}