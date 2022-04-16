namespace MyGame
{
    partial class Program
    {
        public const int MapWidth = 20;
        public const int MapHeight = 9;
        public const int MapLeftMargin = 31;

        static (Cell[,], Player, int) CreateMap(Cell[,] map)
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
            Player player = new Player(0, 0);
            int playerCount = 0, prizeCount = 0;

            for (int y = 1; y < MapHeight - 1; y++)
                for (int x = 1; x < MapWidth - 1; x++)
                {
                    switch (random.Next(0, 100))
                    {
                        case < 10:
                            map[x, y] = new Cell(x, y, CellTypes.Wall);
                            break;

                        case < 15:
                            map[x, y] = new Cell(x, y, CellTypes.Prize);
                            prizeCount++;
                            break;

                        case < 28:
                            map[x, y] = new Cell(x, y, CellTypes.Trap);
                            break;

                        case < 45:
                            map[x, y] = new Cell(x, y, CellTypes.Stop);
                            break;

                        default:
                            if (playerCount == 0)
                            {
                                map[x, y] = new Cell(x, y, CellTypes.Player);
                                player = new Player(x, y);

                                playerCount++;
                            }

                            else map[x, y] = new Cell(x, y, CellTypes.None);
                            break;
                    };

                    map[++x, y] = new Cell(x, y, CellTypes.None);
                }

            if (prizeCount == 0)
            {
                var x = random.Next(2, MapWidth - 1);
                var y = random.Next(1, MapHeight - 1);
                map[x, y] = new Cell(x, y, CellTypes.Prize);
                prizeCount++;
            }

            return (map, player, prizeCount);
        }

        static Cell[,] CopyMap(Cell[,] map)
        {
            Cell[,] newMap = new Cell[MapWidth, MapHeight];

            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                    newMap[x, y] = map[x, y];

            return newMap;
        }

        static void DrawMapAndControls(Cell[,] map)
        {
            Console.SetCursorPosition(0, (Console.WindowHeight - Program.MapHeight) / 2);
            Console.WriteLine(
            "           Controls   \n" +
            "      Q       W       E\n" +
            "   Left Up    ↑   Right Up\n\n" +

            "      A               D\n" +
            "      ←               →\n\n" +

            "      Z       X       C\n" +
            "   Left Down  ↓   Right Down"
            );

            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                    map[i, j].Draw();
        }
    }
}