using System.Drawing;
using CommonCodebase;
using CommonCodebase.Core;
using Pastel;

namespace ConsoleApplication.Screens;

public class MainMenuScreen : ScreenBase
{
    public MainMenuScreen()
    {
        Color = Color.Snow;

        MenuItems = new MenuItems
        {
            { "1. Start Game", ConsoleKey.D1, GameState.Start },
            { "2. Quit", ConsoleKey.D2, GameState.Quit }
        };

        ScreenText.AddFirst(BuildMenuTable(MenuItems.Titles()).ToString());

        ScreenText.AddFirst(Resources.MainMenuLabel.Pastel(Color));
    }
}