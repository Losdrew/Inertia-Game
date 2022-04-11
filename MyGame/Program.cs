namespace MyGame
{
    class Program
    {
        public const int MapWidth = 15;
        public const int MapHeight = 6;
        public const int FrameMs = 200;
        public static int prizeCount = 0;

        public static ConsoleKey[] Controls = {
            ConsoleKey.W, ConsoleKey.X, 
            ConsoleKey.A, ConsoleKey.D, 
            ConsoleKey.Q, ConsoleKey.E, 
            ConsoleKey.Z, ConsoleKey.C
        };

        static void Main()
        {
            Console.CursorVisible = false;

            Cell[,] map = new Cell[MapWidth, MapHeight];

            DrawMap(map);

            var player = SecureRandomPositionForPlayer(map);

            ConsoleKey key;

            while (true)
            {
                key = Console.ReadKey(true).Key;
                int state = 0;

                while (Controls.Contains(key))
                {
                    state = player.Move(map, key);

                    if (state == 0)
                        Thread.Sleep(FrameMs);

                    else break;
                }

                if (state == 2)
                    break;
            }

            Defeat();
        }

        static void DrawMap(Cell[,] map)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                if (x == 0)
                    for (int y = 0; y < MapHeight; y++)
                    {
                         map[x, y] = new Cell(x, y, CellTypes.Wall);
                         map[MapWidth - 1, y] = new Cell(MapWidth - 1, y, CellTypes.Wall);
                    }

                    map[x, 0] = new Cell(x, 0, CellTypes.Wall);
                    map[x, MapHeight - 1] = new Cell(x, MapHeight - 1, CellTypes.Wall);
            }

            var random = new Random();

            for (int x = 2; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    if (x % 2 == 0)
                        switch (random.Next(0, 100))
                        {
                            case < 8:
                                map[x, y] = new Cell(x, y, CellTypes.Wall);
                                break;

                            case < 15:
                                map[x, y] = new Cell(x, y, CellTypes.Prize);
                                prizeCount++;
                                break;

                            case < 30:
                                map[x, y] = new Cell(x, y, CellTypes.Trap);
                                break;

                            case < 45:
                                map[x, y] = new Cell(x, y, CellTypes.Stop);
                                break;

                            default:
                                map[x, y] = new Cell(x, y, CellTypes.None);
                                break;
                        }

                    else map[x, y] = new Cell(x, y, CellTypes.None);
                }
            }

            if (prizeCount == 0)
            {
                var x = random.Next(2, MapWidth - 1);
                var y = random.Next(1, MapHeight - 1);
                map[x, y] = new Cell(x, y, CellTypes.Prize);
            }
            
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                    map[i, j].Draw();
        }

        static Player SecureRandomPositionForPlayer(Cell[,] map)
        {
            var random = new Random();
            var x = random.Next(2, MapWidth - 1);
            var y = random.Next(1, MapHeight - 1);

            while (map[x, y].CellType == CellTypes.Prize)
            {
                x = random.Next(2, MapWidth - 1);
                y = random.Next(1, MapHeight - 1);
            }

            for (int i = x - 2; i <= x + 2; i++)
                for (int j = y - 2; j <= y + 2; j++)
                    if (((0 < i && i < MapWidth - 1) && (0 < j && j < MapHeight - 1))
                        && (map[i, j].CellType == CellTypes.Wall || map[i, j].CellType == CellTypes.Trap))
                            map[i, j].Clear();

            var player = new Player(x, y);
            (map[x, y] = player.PlayerChar).Draw();

            return player;
        }

        static void Defeat()
        {
            for (int i = 0; i < Program.MapHeight * 10; i++)
            {
                Console.WriteLine();
                Thread.Sleep(20);
            }

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("You lose!");
        }
    }
}