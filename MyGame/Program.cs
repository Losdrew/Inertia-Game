using System.Diagnostics;

namespace MyGame
{
    class Program
    {
        public const int MapWidth = 15;
        public const int MapHeight = 6;
        public const int FrameMs = 200;

        static void Main()
        {
            Console.CursorVisible = false;
            
            Cell[,] map = new Cell[MapWidth, MapHeight];
            DrawMap(map);

            var player = SecureRandomPositionForPlayer(map);
            
            Direction currentMovement = Direction.Idle;

            Stopwatch sw = new Stopwatch();

            while (true)
            {
                sw.Restart();

                while (sw.ElapsedMilliseconds <= FrameMs)
                    currentMovement = ReadMovement(currentMovement);

                player.Move(map, currentMovement);
            }

            Console.ReadKey();
        }

        static void DrawMap(Cell[,] map)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                if (x == 0)
                    for (int y = 0; y < MapHeight; y++)
                    {
                         map[x, y] = new Cell(x, y, "Wall");
                         map[MapWidth - 1, y] = new Cell(MapWidth - 1, y, "Wall");
                    }

                    map[x, 0] = new Cell(x, 0, "Wall");
                    map[x, MapHeight - 1] = new Cell(x, MapHeight - 1, "Wall");
            }

            var random = new Random();
            int prizeCount = 0;

            for (int x = 2; x < MapWidth - 1; x++)
            {
                for (int y = 1; y < MapHeight - 1; y++)
                {
                    if (x % 2 == 0)
                        switch (random.Next(0, 100))
                        {
                            case < 8:
                                map[x, y] = new Cell(x, y, "Wall");
                                break;

                            case < 15:
                                map[x, y] = new Cell(x, y, "Prize");
                                prizeCount++;
                                break;

                            case < 25:
                                map[x, y] = new Cell(x, y, "Trap");
                                break;

                            case < 40:
                                map[x, y] = new Cell(x, y, "Stop");
                                break;
                        }
                }
            }

            if (prizeCount == 0)
            {
                var randomCoords = new Coordinates(random.Next(2, MapWidth - 1), random.Next(1, MapHeight - 1));
                map[randomCoords.X, randomCoords.Y] = new Cell(randomCoords, "Prize");
            }
            
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                    map[i, j].Draw();
        }

        static Player SecureRandomPositionForPlayer(Cell[,] map)
        {
            var random = new Random();
            var randomCoords = new Coordinates(random.Next(2, MapWidth - 1), random.Next(1, MapHeight - 1));

            while (map[randomCoords.X, randomCoords.Y].CellType == CellTypes.Prize)
                randomCoords = new Coordinates(random.Next(2, MapWidth - 1), random.Next(1, MapHeight - 1));

            for (int i = randomCoords.X - 1; i <= randomCoords.X + 1; i++)
                for (int j = randomCoords.Y - 1; j <= randomCoords.Y + 1; j++)
                    if ((map[i, j].CellType == CellTypes.Wall || map[i, j].CellType == CellTypes.Trap) &&
                        (i > 0 && i < MapWidth - 1) && (j > 0 && j < MapHeight - 1))
                            map[i, j].Clear();

            var player = new Player(randomCoords);
            map[randomCoords.X, randomCoords.Y] = player.PlayerChar;

            return player;
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!Console.KeyAvailable)
                return currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.W => Direction.Up,
                ConsoleKey.X => Direction.Down,
                ConsoleKey.A => Direction.Left,
                ConsoleKey.D => Direction.Right,
                ConsoleKey.Q => Direction.LeftUp,
                ConsoleKey.E => Direction.RightUp,
                ConsoleKey.Z => Direction.LeftDown,
                ConsoleKey.C => Direction.RightDown,
                _ => currentDirection
            };

            return currentDirection;
        }
    }
}