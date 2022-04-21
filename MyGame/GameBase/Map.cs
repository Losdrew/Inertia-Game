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

        public delegate void ScoreHandler();

        public event ScoreHandler? UpdateScore;

        public Map()
        {
            Matrix = new Cell[MapWidth, MapHeight];
            Player = new(0, 0);
            PrizeCount = 0;
        }

        public Cell this[int x, int y]
        {
            get { return Matrix[x, y]; }
            set { Matrix[x, y] = value; }
        }

        public Map(Map map)
        {
            Matrix = new Cell[MapWidth, MapHeight];

            for (int x = 0; x < MapWidth; x++)
                for (int y = 0; y < MapHeight; y++)
                    Matrix[x, y] = map[x, y];

            Player = new Player(map.Player);
            PrizeCount = map.PrizeCount;
        }

        public void CreateMap()
        {
            for (int x = 0; x < MapWidth; x++)
            {
                if (x == 0)
                    for (int y = 0; y < MapHeight; y++)
                    {
                        Matrix[x, y] = new Wall(x, y);
                        Matrix[MapWidth - 1, y] = new Wall(MapWidth - 1, y);
                    }

                Matrix[x, 0] = new Wall(x, 0);
                Matrix[x, MapHeight - 1] = new Wall(x, MapHeight - 1);
            }

            var random = new Random();

            for (int y = 1; y < MapHeight - 1; y++)
                for (int x = 1; x < MapWidth - 1; x++)
                {
                    Matrix[x, y] = random.Next(0, 100) switch
                    {
                        < 10 => new Wall(x, y),
                        < 15 => ((Func<Prize>)(() => { 
                            PrizeCount++; 
                            return new Prize(x, y); 
                        }))(),
                        < 28 => new Trap(x, y),
                        < 45 => new Stop(x, y),
                        _ => new Cell(x, y)
                    };

                    Matrix[++x, y] = new Cell(x, y);
                }

            var randX = random.Next(1, MapWidth - 1);
            var randY = random.Next(1, MapHeight - 1);
            Matrix[randX, randY] = new Player(randX, randY);
            Player = new Player(randX, randY);

            if (PrizeCount == 0)
            {
                randX = random.Next(2, MapWidth - 1);
                randY = random.Next(1, MapHeight - 1);
                Matrix[randX, randY] = new Prize(randX, randY);
                PrizeCount++;
            }
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
            Console.WriteLine(
            "           Controls   \n" +
            "      Q       W       E\n" +
            "   Left Up    ↑   Right Up\n\n" +

            "      A               D\n" +
            "      ←               →\n\n" +

            "      Z       X       C\n" +
            "   Left Down  ↓   Right Down");

            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                    Matrix[i, j].Draw();
        }
    }
}
