using CommonCodebase.Core;

namespace CommonCodebase.Miscellaneous;

public class ControlsTip : VisualObject
{
    public const int Width = 38;
    private const int Height = 13 / 2 + 1;

    public string Text { get; }

    public ControlsTip()
    {
        X = 0;
        Y = Map.Height - Height;

        Text = Resources.ControlsTip;
    }

    public static event EventHandler? DrawControls;

    public override void Draw()
    {
        DrawControls?.Invoke(this, EventArgs.Empty);
    }
}