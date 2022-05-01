namespace MyGame
{
    class Map : VisualObject
    {
        public static int MapWidth = 20;
        public static int MapHeight = 9;
        public static int MapLeftMargin = 31;

        public Cell[,] Matrix { get; set; }

        public Player Player { get; set; }

        public int PrizeCount { get; set; }

        public Map()
        {
            Matrix = new Cell[MapWidth, MapHeight];
            Player = new(0, 0);
        }

        public Map(Map map)
        {
            Matrix = new Cell[MapWidth, MapHeight];

            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                    Matrix[x, y] = map[x, y];
                
            Player = new Player(map.Player.X, map.Player.Y);
            PrizeCount = map.PrizeCount;
        }

        public delegate void ScoreHandler();

        public event ScoreHandler? UpdateScore;

        public Cell this[int x, int y]
        {
            get { return Matrix[x, y]; }
            set { Matrix[x, y] = value; }
        }

        public void CreateMap()
        {
            var random = new Random();

            var pathLength = random.Next(1, (MapWidth - 2) * (MapHeight - 2) / 4);

            var start = (random.Next(1, MapWidth - 1), random.Next(1, MapHeight - 1));

            var (x, y) = start;

            Matrix[x, y] = new Cell(x, y);
            Player = new(x, y);
            pathLength--;

            var directions = Enum.GetValues<Direction>();

            var currentDirection = GetRandomDirection(random, directions);

            while (pathLength > 0)
            {
                var moveTo = GetDestination(x, y, currentDirection);

                if (Matrix[moveTo.x, moveTo.y] is Prize || moveTo == (x, y))
                {
                    currentDirection = GetRandomDirection(random, directions);
                    continue;
                }
                    
                (x, y) = moveTo;

                pathLength--;

                switch (random.Next(100))
                {
                    case < 15: CreateCell(x, y, "WallAhead", currentDirection); break;
                    case < 25: CreateCell(x, y, "Prize"); break;
                    case < 45: CreateCell(x, y, "Stop"); break;
                    default: CreateCell(x, y, "Cell"); continue;
                };

                currentDirection = GetRandomDirection(random, directions);
            }

            if (PrizeCount == 0)
            {
                Matrix[x, y] = new Prize(x, y);
                PrizeCount++;
            }

            for (y = 0; y < MapHeight; y++)
            {
                for (x = 0; x < MapWidth; x++)
                {
                    if (Matrix[x, y] == null)
                    {
                        if (!IsInRangeOfMap(x, y))
                        {
                            Matrix[x, y] = new Wall(x, y);
                            continue;
                        }
                            
                        switch (random.Next(100))
                        {
                            case < 15: CreateCell(x, y, "WallAt"); break;
                            case < 28: CreateCell(x, y, "Trap"); break;
                            case < 45: CreateCell(x, y, "Stop"); break;
                            default: CreateCell(x, y, "Cell"); break;
                        };

                        if (x + 1 < MapWidth - 1 && Matrix[x + 1, y] == null)
                            Matrix[++x, y] = new Cell(x, y);
                    }
                }
            }
        }

        public Direction GetRandomDirection(Random random, Direction[] directions) =>
            directions[random.Next(directions.Length)];

        public bool IsInRangeOfMap(int x, int y) =>
            (0 < x && x < MapWidth - 1) && (0 < y && y < MapHeight - 1);

        public (int x, int y) GetDestination(int x, int y, Direction direction)
        {
            (int x, int y) result = direction switch
            {
                Direction.Up => (x, y - 1),
                Direction.Down => (x, y + 1),
                Direction.Left => (x - 1, y),
                Direction.Right => (x + 1, y),
                Direction.LeftUp => (x - 1, y - 1),
                Direction.RightUp => (x + 1, y - 1),
                Direction.LeftDown => (x - 1, y + 1),
                Direction.RightDown => (x + 1, y + 1),
            };

            return IsInRangeOfMap(result.x, result.y) ? result : (x, y);
        }

        public void CreateCell(int x, int y, string cellType, Direction direction = 0)
        {
            switch (cellType)
            {
                case "Prize":
                    Matrix[x, y] = new Prize(x, y);
                    PrizeCount++;
                    break;

                case "Stop":
                    Matrix[x, y] = new Stop(x, y);
                    break;

                case "Trap":
                    Matrix[x, y] = new Trap(x, y);
                    break;

                case "WallAhead":
                    Matrix[x, y] = new Cell(x, y);
                    var (newX, newY) = GetDestination(x, y, direction);
                    if (Matrix[newX, newY] == null && (newX, newY) != (x, y))
                        Matrix[newX, newY] = new Wall(newX, newY);
                    break;

                case "WallAt":
                    Matrix[x, y] = new Wall(x, y);
                    break;

                default:
                    Matrix[x, y] = new Cell(x, y);
                    break;
            };
        }

        public void ClearCell(int x, int y)
        {
            if (Matrix[x, y] is Prize)
            {
                PrizeCount--;
                UpdateScore?.Invoke();
            }

            Matrix[x, y] = new Cell(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(0, (Console.WindowHeight - Map.MapHeight) / 2);

            // Draw controls
            var path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Miscellaneous/Controls.txt";

            List<Direction> directions = new()
            {
                Direction.LeftUp, Direction.Up, Direction.RightUp, Direction.Left,
                Direction.Right, Direction.LeftDown, Direction.Down, Direction.RightDown,
            };
            
            using var sr = new StreamReader(path);
            var str = sr.ReadToEnd();

            for (int i = 0; str.Contains(i.ToString()); i++)
                str = str.Replace(i.ToString(), ((ConsoleKey)directions[i]).ToString());

            // Draw map
            for (int y = 0; y < MapHeight; y++)
                for (int x = 0; x < MapWidth; x++)
                    Matrix[x, y].Draw();

            // Draw player
            Player.Draw();
        }
    }
}
