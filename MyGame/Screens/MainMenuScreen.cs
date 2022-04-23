namespace MyGame
{
    class MainMenuScreen : Screen
    {
        public MainMenuScreen()
        {
            Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/MainMenu.txt";
            WindowSize = (113, 43);
            CursorPosition = (66, 14);
            Color = ConsoleColor.White;

            Choice = new()
            {
                { ConsoleKey.D1, GameState.Start },
                { ConsoleKey.D2, GameState.Quit }
            };
        }
    }
}
