using System.Drawing;
using CommonCodebase;
using CommonCodebase.Core;
using Pastel;

namespace ConsoleApplication.Screens;

public class WinScreen : ScreenBase
{
    public WinScreen()
    {
        Color = Color.FromArgb(12, 216, 0);

        MenuItems = new MenuItems
        {
            { "1. Continue", ConsoleKey.D1, GameState.Continue },
            { "2. Restart current level", ConsoleKey.D2, GameState.Restart },
            { "3. Quit", ConsoleKey.D3, GameState.Quit }
        };

        ScreenText.AddFirst(BuildMenuTable(MenuItems.Titles()).ToString());

        ScreenText.AddFirst(Resources.WinLabel.Pastel(Color));
    }
}