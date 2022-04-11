namespace MyGame
{
    public class Player
    {
        public static CellTypes[] ToStopAt = { CellTypes.Trap, CellTypes.Stop };
        public static Dictionary<ConsoleKey, Coordinates> directionCoords = 
            new Dictionary<ConsoleKey, Coordinates>()
            {
                { ConsoleKey.W, new Coordinates(0, -1) },
                { ConsoleKey.X, new Coordinates(0, 1) },
                { ConsoleKey.A, new Coordinates(-1, 0) },
                { ConsoleKey.D, new Coordinates(1, 0) },
                { ConsoleKey.Q, new Coordinates(-1, -1) },
                { ConsoleKey.E, new Coordinates(1, -1) },
                { ConsoleKey.Z, new Coordinates(-1, 1) },
                { ConsoleKey.C, new Coordinates(1, 1) },
            };
        
        public Cell PlayerChar { get; set; }

        public Player(int x, int y)
        {
            PlayerChar = new Cell(x, y, CellTypes.Player);
        }

        public int Move(Cell[,] map, ConsoleKey key)
        {
            int state = 0;

            Clear();

            var movedPlayer = new Cell(map[PlayerChar.X + directionCoords[key].X, PlayerChar.Y + directionCoords[key].Y]);

            switch (movedPlayer.CellType)
            {
                case CellTypes.Wall:
                    state = 1;
                    break;

                case CellTypes.Stop:
                    map[PlayerChar.X, PlayerChar.Y] = new Cell(PlayerChar.X, PlayerChar.Y, CellTypes.None);
                    PlayerChar = new Cell(movedPlayer.X, movedPlayer.Y, CellTypes.Player);
                    break;

                case CellTypes.Trap:
                    state = 2;
                    break;

                default:
                    PlayerChar = new Cell(movedPlayer.X, movedPlayer.Y, CellTypes.Player);
                    break;
            }

            Draw();

            return state;
        }

        public void Draw()
        {
            PlayerChar.Draw();
        }

        public void Clear()
        {
            PlayerChar.Clear();
        }
    }
}
