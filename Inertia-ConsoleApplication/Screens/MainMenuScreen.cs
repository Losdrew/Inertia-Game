using CommonCodebase.Core;
using ConsoleApplication;
using System.Drawing;

namespace Screens;

public class MainMenuScreen : ScreenBase
{
    public MainMenuScreen()
    {
        Color = Color.Snow;

        Label = Resources.MainMenuLabel;

        MenuItems = new List<MenuItem>
        {
            new("1. Start Game", ConsoleKey.D1, GameState.Start),
            new("2. Quit", ConsoleKey.D2, GameState.Quit)
        };
    }
}