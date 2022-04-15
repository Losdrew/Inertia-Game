namespace MyGame
{
    public enum PlayerState
    {
        Moving,
        Stopped,
        GameOver
    }

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

        public Cell PlayerChar { get; set;}

        public Player(int x, int y)
        {
            PlayerChar = new Cell(x, y, CellTypes.Player);
        }

        public PlayerState Move(Cell[,] map, ConsoleKey key, ref int prizeCount)
        {
            PlayerState state = PlayerState.Moving;

            map[PlayerChar.X, PlayerChar.Y].Clear();

            var movedPlayer = map[PlayerChar.X + directionCoords[key].X, PlayerChar.Y + directionCoords[key].Y];

            switch (movedPlayer.CellType)
            {
                case CellTypes.Wall:
                    state = PlayerState.Stopped;
                    break;

                case CellTypes.Trap:
                    state = PlayerState.GameOver;
                    break;

                case CellTypes.Stop:
                    PlayerChar = new Cell(movedPlayer.X, movedPlayer.Y, CellTypes.Player);
                    goto case CellTypes.Wall;

                case CellTypes.Prize:
                    prizeCount--;
                    goto case CellTypes.Stop;

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
