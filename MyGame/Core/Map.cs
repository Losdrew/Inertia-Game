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

        public Cell this[int x, int y]
        {
            get { return Matrix[x, y]; }
            set { Matrix[x, y] = value; }
        }

        public delegate void ScoreHandler();

        public event ScoreHandler? UpdateScore;

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

            Player = new Player(map.Player);
            PrizeCount = map.PrizeCount;
        }

        public void CreateMap()
        {
            var random = new Random();

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if ((0 < y && y < MapHeight - 1) && (0 < x && x < MapWidth - 1))
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

                    else Matrix[x, y] = new Wall(x, y);
                }
            }

            var (randX, randY) = RandomCoordinates(random);

            if (PrizeCount == 0)
            {
                Matrix[randX, randY] = new Prize(randX, randY);
                PrizeCount++;
            }

            while (Matrix[randX, randY] is Prize)
                (randX, randY) = RandomCoordinates(random);

            Player = new Player(randX, randY);
        }

        private (int x, int y) RandomCoordinates(Random random) => 
            (random.Next(2, MapWidth - 1), random.Next(1, MapHeight - 1));

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

            Player.Draw();
        }
    }
}
