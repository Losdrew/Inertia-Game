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

    class Program
    {
        public const int FrameMs = 120;

        public static ConsoleKey[] Controls = {
            ConsoleKey.W, ConsoleKey.X, 
            ConsoleKey.A, ConsoleKey.D, 
            ConsoleKey.Q, ConsoleKey.E, 
            ConsoleKey.Z, ConsoleKey.C
        };

        static void Main()
        {
            MainMenu.Show();

            GameState currentGameState = MainMenu.GetInput();

            if (currentGameState == GameState.Start)
            {
                Score score = new();

                while (currentGameState != GameState.Quit)
                {
                    Map map = new();
                    map.CreateMap();

                    while (currentGameState != GameState.Continue)
                    {
                        currentGameState = Play(map, score);

                        if (currentGameState == GameState.Win)
                        {
                            if (Win() == GameState.Continue)
                            {
                                score.Save();
                                break;
                            }
                            
                            else score.CurrentScore = 0;
                        }

                        else
                        {
                            if (GameOver() == GameState.CreateNew)
                            {
                                score.Reset();
                                break;
                            }

                            else score.CurrentScore = 0;
                        }    
                    }
                }
            }

            else Environment.Exit(1);
        }

        static GameState Win()
        {
            WinScreen.Show();

            return WinScreen.GetInput();
        }

        static GameState GameOver()
        {
            GameOverScreen.Show();

            return GameOverScreen.GetInput();
        }

        static GameState Play(Map map, Score score)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(Map.MapLeftMargin * 2 + Map.MapWidth, Map.MapHeight * 2);
            Console.SetBufferSize(Map.MapLeftMargin * 2 + Map.MapWidth, Map.MapHeight * 2);

            Map currentMap = new(map);

            currentMap.Draw();
            score.Draw();

            currentMap.UpdateScore += score.Update;

            ConsoleKey key;

            while (true)
            {
                key = Console.ReadKey(true).Key;

                while (Controls.Contains(key))
                {
                    var state = currentMap.Player.Move(currentMap, key);

                    if (state == PlayerState.Moving)
                        Thread.Sleep(FrameMs);

                    else if (state == PlayerState.Win)
                        return GameState.Win;

                    else if (state == PlayerState.GameOver)
                        return GameState.GameOver;

                    else break;
                } 
            }
        }
    }
}