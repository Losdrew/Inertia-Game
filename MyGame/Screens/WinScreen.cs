using System.Drawing;
using MyGame.Core;

namespace MyGame.Screens;

public class WinScreen : ScreenBase
{
    public WinScreen()
    {
        WindowSize = (119, 41);
        Text = Resources.WinScreen;
        Color = Color = Color.FromArgb(12, 216, 0);

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Continue },
            { ConsoleKey.D2, GameState.Restart },
            { ConsoleKey.D3, GameState.Quit }
        };
    }
}