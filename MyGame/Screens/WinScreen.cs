using MyGame.Miscellaneous;

namespace MyGame.Screens;

public class WinScreen : ScreenBase
{
    public WinScreen()
    {
        Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/Win.txt";
        WindowSize = (119, 42);
        Color = ConsoleColor.Green;

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Continue },
            { ConsoleKey.D2, GameState.Play },
            { ConsoleKey.D3, GameState.Quit }
        };
    }
}