using System.Drawing;
using MyGame.Core;

namespace MyGame.Screens;

public class MainMenuScreen : ScreenBase
{
    public MainMenuScreen()
    {
        WindowSize = (107, 43);
        Text = Resources.MainMenuScreen;
        Color = Color.Snow;

        Choice = new Dictionary<ConsoleKey, GameState>
        {
            { ConsoleKey.D1, GameState.Start },
            { ConsoleKey.D2, GameState.Quit }
        };
    }
}