namespace MyGame
{
    class MovementHandler
    {
        private const int FrameMs = 120;

        public bool Move(Map map)
        {
            ConsoleKey key;

            while (true)
            {
                key = Console.ReadKey(true).Key;

                while (Enum.IsDefined(typeof(Direction), (Direction)key))
                {
                    (int x, int y) = (Direction)key switch
                    {
                        Direction.Up => (map.Player.X, map.Player.Y - 1),
                        Direction.Down => (map.Player.X, map.Player.Y + 1),
                        Direction.Left => (map.Player.X - 1, map.Player.Y),
                        Direction.Right => (map.Player.X + 1, map.Player.Y),
                        Direction.LeftUp => (map.Player.X - 1, map.Player.Y - 1),
                        Direction.RightUp => (map.Player.X + 1, map.Player.Y - 1),
                        Direction.LeftDown => (map.Player.X - 1, map.Player.Y + 1),
                        Direction.RightDown => (map.Player.X + 1, map.Player.Y + 1)
                    };

                    if (map[x, y] is Wall)
                        break;

                    if (map[x, y] is Trap)
                        return false;

                    map.Player.Clear();

                    (map.Player.X, map.Player.Y) = (x, y);

                    map.Player.Draw();

                    if (map[x, y] is Prize or Stop)
                    {
                        map.ClearCell(x, y);

                        if (map.PrizeCount == 0)
                            return true;

                        break;
                    }

                    Thread.Sleep(FrameMs);
                }
            }
        }
    }
}
