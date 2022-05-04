using MyGame.Miscellaneous;

namespace MyGame.Screens;

public class WinScreen : Screen
{
    public WinScreen()
    {
        Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/Win.txt";
        WindowSize = (125, 42);
        CursorPosition = (72, 12);
        Color = ConsoleColor.Green;

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Continue },
            { ConsoleKey.D2, GameState.Play },
            { ConsoleKey.D3, GameState.Quit }
        };
    }
}