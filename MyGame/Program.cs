#pragma warning disable CA1416

namespace MyGame
{
    class Program
    {
        public const int FrameMs = 120;

        static void Main()
        {    
            Score score = new();
            Map? map = null;

            var currentGameState = GameState.InMenu;

            while (currentGameState != GameState.Quit)
            {
                currentGameState = currentGameState switch
                {
                    GameState.InMenu => Menu(),
                    GameState.Start => Start(out map),
                    GameState.Play => Play(map, score),
                    GameState.Win => Win(),
                    GameState.GameOver => GameOver(),
                    GameState.Continue => Continue(score),
                    GameState.CreateNew => CreateNew(score),
                };
            }

            Environment.Exit(0);
        }

        static GameState Menu() => new MainMenuScreen().GetInput();
        static GameState Win() => new WinScreen().GetInput();
        static GameState GameOver() => new GameOverScreen().GetInput();

        static GameState Start(out Map map)
            { (map = new()).CreateMap(); return GameState.Play; }

        static GameState Continue(Score score) 
            { score.Save(); return GameState.Start; }

        static GameState CreateNew(Score score) 
            { score.ResetAll(); return GameState.Start; }

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

            score.ResetCurrent();

            ConsoleKey key;

            while (true)
            {
                key = Console.ReadKey(true).Key;

                while (Enum.IsDefined(typeof(Direction), (Direction)key))
                {
                    var state = currentMap.Player.Move(currentMap, (Direction)key);

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