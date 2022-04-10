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
        public Coordinates Coordinates { get; }

        public CellTypes CellType { get; set; }

        public ConsoleColor Color { get; set; }

        public Cell(int x, int y, string type)
        {
            Coordinates = new Coordinates(x, y);
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
        }
        
        public Cell(Coordinates coordinates, string type) : this(coordinates.X, coordinates.Y, type) { }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Coordinates.X, Coordinates.Y);
            Console.Write((char)CellType);
        }

        public void Clear()
        {
            Console.SetCursorPosition(Coordinates.X, Coordinates.Y);
            CellType = 0;
            Color = 0;
            Console.Write(" ");
        }
    }
}
