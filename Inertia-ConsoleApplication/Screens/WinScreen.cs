using CommonCodebase.Core;
using System.Drawing;

namespace ConsoleApplication.Screens;

public class WinScreen : ScreenBase
{
    public WinScreen()
    {
        Color = Color.FromArgb(12, 216, 0);

        Label = Resources.WinLabel;

        MenuItems = new List<MenuItem>
        {
            new("1. Continue", ConsoleKey.D1, GameState.Continue),
            new("2. Restart current level", ConsoleKey.D2, GameState.Restart),
            new("3. Quit", ConsoleKey.D3, GameState.Quit)
        };
    }
}