#pragma warning disable CA1416

namespace MyGame
{
    public enum GameState
    {
        Start,
        Win,
        GameOver,
        Retry,
        CreateNew,
        Continue,
        Quit
    }

    partial class Program
    {
        public const int FrameMs = 150;

        public static ConsoleKey[] Controls = {
            ConsoleKey.W, ConsoleKey.X, 
            ConsoleKey.A, ConsoleKey.D, 
            ConsoleKey.Q, ConsoleKey.E, 
            ConsoleKey.Z, ConsoleKey.C
        };

        static void Main()
        {
            MainMenu.Show();

            if (MainMenu.GetInput() == GameState.Start)
            {
                Score score = new Score();

                while (true)
                {
                    (Cell[,] map, Player player, int prizeCount) = CreateMap(new Cell[MapWidth, MapHeight]);

                    while (true)
                    {
                        if (Play(map, player, prizeCount, score) == GameState.Win)
                        {
                            WinScreen.Show();
                            score.CurrentScore++;

                            if (WinScreen.GetInput() == GameState.Continue)
                            {
                                score.Save();
                                break;
                            }
                        }

                        else
                        {
                            GameOverScreen.Show();

                            if (GameOverScreen.GetInput() == GameState.CreateNew)
                            {
                                score.Reset();
                                break;
                            } 
                        }
                    }
                }
            }

            else System.Environment.Exit(1);
        }

        static GameState Play(Cell[,] initialMap, Player initialPlayer, int initialPrizeCount, Score score)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(MapLeftMargin * 2 + MapWidth, MapHeight * 2);
            Console.SetBufferSize(MapLeftMargin * 2 + MapWidth, MapHeight * 2); 

            Cell[,] currentMap = CopyMap(initialMap);
            Player player = new Player(initialPlayer.PlayerChar.X, initialPlayer.PlayerChar.Y);

            int currentPrizeCount = initialPrizeCount;

            DrawMapAndControls(currentMap);
            score.Draw();

            ConsoleKey key;
            PlayerState state;

            while (true)
            {
                if (initialPrizeCount - currentPrizeCount > score.CurrentScore)
                    score.Update();

                key = Console.ReadKey(true).Key;

                while (Controls.Contains(key))
                {
                    state = player.Move(currentMap, key, ref currentPrizeCount);

                    if (state == PlayerState.Moving)
                        Thread.Sleep(FrameMs);

                    else if (currentPrizeCount == 0)
                        return GameState.Win;

                    else if (state == PlayerState.GameOver)
                        return GameState.GameOver;
                    
                    else break;
                } 
            }
        }
    }
}