using System.Drawing;
using MyGame.Core;
using Pastel;

namespace MyGame.Screens;

public class GameOverScreen : ScreenBase
{
    public GameOverScreen()
    {
        Color = Color.FromArgb(255, 65, 82);

        MenuItems = new MenuItems
        {
            { "1. Restart current level", ConsoleKey.D1, GameState.Restart },
            { "2. Create new level", ConsoleKey.D2, GameState.CreateNew },
            { "3. Quit", ConsoleKey.D3, GameState.Quit }
        };

        ScreenText.AddFirst(BuildMenuTable(MenuItems.Titles()).ToString());

        ScreenText.AddFirst(Resources.GameOverLabel.Pastel(Color));
    }
}