using ConsoleApplication.Properties;
using System.Drawing;

namespace ConsoleApplication.Screens;

internal class GameOverScreen : ScreenBase
{
    public GameOverScreen()
    {
        Color = Color.FromArgb(255, 65, 82);

        Label = Resources.GameOverLabel;

        MenuItems = new List<MenuItem>
        {
            new("1. Restart current level", ConsoleKey.D1, GameState.Restart),
            new("2. Create new level", ConsoleKey.D2, GameState.CreateNew),
            new("3. Quit", ConsoleKey.D3, GameState.Quit)
        };
    }
}