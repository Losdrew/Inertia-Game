namespace MyGame
{
    class Player : Cell
    {
        public Player(int x, int y) : base(x, y)
        {
            CellType = 'I';
            Color = ConsoleColor.DarkCyan;
        }

        public Player(Player player) : this(player.X, player.Y) { }

        private void Clear()
        {
            Console.SetCursorPosition(
               Map.MapLeftMargin + X,
               (Console.WindowHeight - Map.MapHeight) / 2 + Y);

            Console.Write(' ');
        }

        public PlayerState Move(Map map, Direction direction)
        {
            var movedPlayer = GetCellInDirection(map, direction);

            if (movedPlayer is Wall)
                return PlayerState.Stopped;

            if (movedPlayer is Trap)
                return PlayerState.GameOver;

            Clear();

            (X, Y) = (movedPlayer.X, movedPlayer.Y);

            Draw();

            if (map[X, Y] is Prize or Stop)
            {
                map.ClearCell(X, Y);

                if (map.PrizeCount == 0)
                    return PlayerState.Win;

                return PlayerState.Stopped;
            }

            return PlayerState.Moving;
        }

        private Cell GetCellInDirection(Map map, Direction direction)
        {
            return direction switch
            {
                Direction.Up => map[X, Y - 1],
                Direction.Down => map[X, Y + 1],
                Direction.Left => map[X - 1, Y],
                Direction.Right => map[X + 1, Y],
                Direction.LeftUp => map[X - 1, Y - 1],
                Direction.RightUp => map[X + 1, Y - 1],
                Direction.LeftDown => map[X - 1, Y + 1],
                Direction.RightDown => map[X + 1, Y + 1],
                _ => map[X, Y]
            };
        }
    }
}
