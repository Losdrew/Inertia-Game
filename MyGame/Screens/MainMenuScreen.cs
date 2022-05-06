using MyGame.Miscellaneous;

namespace MyGame.Screens;

public class MainMenuScreen : ScreenBase
{
    public MainMenuScreen()
    {
        Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/MainMenu.txt";
        WindowSize = (107, 44);
        Color = ConsoleColor.White;

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Start },
            { ConsoleKey.D2, GameState.Quit }
        };
    }
}