namespace CommonCodebase.Miscellaneous;

public class ControlsTip : LabelBase
{
    public ControlsTip()
    {
        Height = CalculateHeight();
    }

    public static int Height { get; private set; }

    public static event EventHandler? DrawControlsTip;

    public override void Draw()
    {
        DrawControlsTip?.Invoke(this, EventArgs.Empty);
    }
}