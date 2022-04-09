namespace MyGame
{
    class Program
    {
        public const int MapWidth = 15;
        public const int MapHeight = 6;

        static void Main()
        {
            Console.CursorVisible = false;
            
            Cell[,] map = new Cell[MapWidth, MapHeight];
            DrawMap(map);

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

            Random random = new Random();
            int playerCount = 0, prizeCount = 0;

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

                            default:
                                if (playerCount == 0)
                                    map[x, y] = new Cell(x, y, "Player");
                                playerCount++;
                                break;
                        }
                }
            }

            if (prizeCount == 0)
            {
                var randX = random.Next(3, MapWidth - 2);
                var randY = random.Next(1, MapHeight - 1);
                map[randX, randY] = new Cell(randX, randY, "Prize");
            }
                   
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                    map[i, j].Draw();
        }
    }
}