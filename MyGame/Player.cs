namespace MyGame
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        LeftUp,
        RightUp,
        LeftDown,
        RightDown,
        Idle
    }

    public class Player
    {
        public Cell PlayerChar { get; set; }

        public Player(int x, int y)
        {
            PlayerChar = new Cell(x, y, "Player");
        }

        public Player(Coordinates coordinates) : this(coordinates.X, coordinates.Y) { }

        public void Move(Cell[,] map, Direction direction)
        {
            Clear();

            PlayerChar = direction switch
            {
                Direction.Up when (map[PlayerChar.Coordinates.X, PlayerChar.Coordinates.Y - 1].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X, PlayerChar.Coordinates.Y - 1, "Player"),

                Direction.Down when (map[PlayerChar.Coordinates.X, PlayerChar.Coordinates.Y + 1].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X, PlayerChar.Coordinates.Y + 1, "Player"),

                Direction.Left when (map[PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y, "Player"),

                Direction.Right when (map[PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y, "Player"),

                Direction.LeftUp when (map[PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y - 1].CellType != CellTypes.Wall) =>
                    new Cell(PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y - 1, "Player"),

                Direction.RightUp when (map[PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y - 1].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y - 1, "Player"),

                Direction.LeftDown when (map[PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y + 1].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X - 1, PlayerChar.Coordinates.Y + 1, "Player"),

                Direction.RightDown when (map[PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y + 1].CellType != CellTypes.Wall) => 
                    new Cell(PlayerChar.Coordinates.X + 1, PlayerChar.Coordinates.Y + 1, "Player"),

                _ => PlayerChar
            };

            Draw();
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
