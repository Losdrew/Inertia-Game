namespace MyGame
{
    public enum PlayerState
    {
        Moving,
        Stopped,
        Win,
        GameOver
    }

    class Player : Cell
    {
        private Dictionary<ConsoleKey, Coordinates> directionCoords = new()
        {
            { ConsoleKey.W, new Coordinates(0, -1) },
            { ConsoleKey.X, new Coordinates(0, 1) },
            { ConsoleKey.A, new Coordinates(-1, 0) },
            { ConsoleKey.D, new Coordinates(1, 0) },
            { ConsoleKey.Q, new Coordinates(-1, -1) },
            { ConsoleKey.E, new Coordinates(1, -1) },
            { ConsoleKey.Z, new Coordinates(-1, 1) },
            { ConsoleKey.C, new Coordinates(1, 1) }
        };

        public Player(int x, int y) : base(x, y)
        {
            CellType = 'I';
            Color = ConsoleColor.DarkCyan;
            MoveType = MoveTypes.GoThrough;
        }

        public Player(Player player) : this(player.X, player.Y) { }

        public void Clear()
        {
            Console.SetCursorPosition(
               Map.MapLeftMargin + X,
               (Console.WindowHeight - Map.MapHeight) / 2 + Y);

            Console.Write(' ');
        }

        public PlayerState Move(Map map, ConsoleKey key)
        {
            var movedPlayer = map[X + directionCoords[key].X, Y + directionCoords[key].Y];
            
            if (movedPlayer.MoveType == MoveTypes.StopBefore)
                return PlayerState.Stopped;

            Clear();

            X = movedPlayer.X;
            Y = movedPlayer.Y;

            Draw();

            if (map[X, Y] is Prize or Stop)
            {
                map.ClearCell(X, Y);

                if (map.PrizeCount == 0)
                    return PlayerState.Win;

                return PlayerState.Stopped;
            }

            if (map[X, Y] is Trap)
                return PlayerState.GameOver;

            return PlayerState.Moving;
        }
    }
}
