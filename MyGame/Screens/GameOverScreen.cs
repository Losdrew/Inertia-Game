using MyGame.Miscellaneous;

namespace MyGame.Screens;

public class GameOverScreen : ScreenBase
{
    public GameOverScreen()
    {
        Path = "C:/Users/Losdr/source/repos/MyGame/MyGame/Screens/.txtScreens/GameOver.txt";
        WindowSize = (119, 41);
        Color = ConsoleColor.Red;

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Play },
            { ConsoleKey.D2, GameState.CreateNew },
            { ConsoleKey.D3, GameState.Quit }
        };
    }
}