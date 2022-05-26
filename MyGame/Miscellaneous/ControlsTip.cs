using MyGame.Core;

namespace MyGame.Miscellaneous;

public class ControlsTip : VisualObject
{
    public const int Width = 38;
    private const int Height = 13 / 2 + 1;

    private readonly List<Enum> _controls = new()
    {
        Direction.LeftUp, Direction.Up, Direction.RightUp, 
        Direction.Left, Direction.Right, 
        Direction.LeftDown, Direction.Down, Direction.RightDown,
        MusicControls.PauseMusic, MusicControls.SwitchMusic
    };

    private string Text { get; }

    public ControlsTip()
    {
        X = 0;
        Y = Map.Height - Height;

        Text = Resources.ControlsTip;

        // Replace numbers in controls string with corresponding keys
        for (var i = 0; Text.Contains(i.ToString()); i++)
            Text = Text.Replace(i.ToString(), ((ConsoleKey)_controls[i]).ToString());
    }

    public override void Draw()
    {
        SetPosition();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write(Text);
    }

    private void SetPosition()
    {
        Console.SetCursorPosition(X, Y);
    }
}
