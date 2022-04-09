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
        RightDown
    }

    public class Player
    {
        public Cell PlayerChar { get; set; }

        public Player(int x, int y)
        {
            PlayerChar = new Cell(x, y, "Player");
        }

        public void Move(Direction direction)
        {
            Clear();

            PlayerChar = direction switch
            {
                Direction.Up => new Cell(PlayerChar.X, PlayerChar.Y + 1, "Player"),
                Direction.Down => new Cell(PlayerChar.X, PlayerChar.Y - 1, "Player"),
                Direction.Left => new Cell(PlayerChar.X - 1, PlayerChar.Y, "Player"),
                Direction.Right => new Cell(PlayerChar.X + 1, PlayerChar.Y, "Player"),
                Direction.LeftUp => new Cell(PlayerChar.X - 1, PlayerChar.Y + 1, "Player"),
                Direction.RightUp => new Cell(PlayerChar.X + 1, PlayerChar.Y + 1, "Player"),
                Direction.LeftDown => new Cell(PlayerChar.X - 1, PlayerChar.Y - 1, "Player"),
                Direction.RightDown => new Cell(PlayerChar.X + 1, PlayerChar.Y - 1, "Player")
            };
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
