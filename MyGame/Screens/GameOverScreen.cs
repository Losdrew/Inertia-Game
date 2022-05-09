using System.Drawing;
using MyGame.Miscellaneous;

namespace MyGame.Screens;

public class GameOverScreen : ScreenBase
{
    public GameOverScreen()
    {
        WindowSize = (119, 40);
        Text = Resources.GameOverScreen;
        Color = Color.FromArgb(255, 65, 82);

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Play },
            { ConsoleKey.D2, GameState.CreateNew },
            { ConsoleKey.D3, GameState.Quit }
        };
    }
}