namespace MyGame
{
    public enum CellTypes
    {
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
        public int X { get; }

        public int Y { get; }

        public CellTypes CellType { get; }

        public ConsoleColor Color { get; }

        public Cell(int x, int y, string type)
        {
            X = x;
            Y = y;
            CellType = (CellTypes)Enum.Parse(typeof(CellTypes), type);

            switch (CellType)
            {
                case CellTypes.Player:
                    Color = (ConsoleColor)CellColors.Player;
                    break;

                case CellTypes.Prize:
                    Color = (ConsoleColor)CellColors.Prize;
                    break;

                case CellTypes.Stop:
                    Color = (ConsoleColor)CellColors.Stop;
                    break;

                case CellTypes.Wall:
                    Color = (ConsoleColor)CellColors.Wall;
                    break;

                case CellTypes.Trap:
                    Color = (ConsoleColor)CellColors.Trap;
                    break;

                default:
                    Color = 0;
                    break;
            }     

            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write((char)CellType);
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write((char)CellType);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
