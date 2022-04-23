namespace MyGame
{
    class GameOverScreen : Screen
    {
        public GameOverScreen()
        {
            Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/GameOver.txt";
            WindowSize = (133, 42);
            CursorPosition = (78, 11);
            Color = ConsoleColor.Red;

            Choice = new()
            {
                { ConsoleKey.D1, GameState.Play },
                { ConsoleKey.D2, GameState.CreateNew },
                { ConsoleKey.D3, GameState.Quit }
            };
        }
    }
}
