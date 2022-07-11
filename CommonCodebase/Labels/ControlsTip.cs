namespace CommonCodebase.Labels;

public class ControlsTip : LabelBase
{
    public static event EventHandler? DrawControlsTip;

    public override void Draw()
    {
        DrawControlsTip?.Invoke(this, EventArgs.Empty);
    }
}