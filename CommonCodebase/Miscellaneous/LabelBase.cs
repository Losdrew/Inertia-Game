using CommonCodebase.Core;

namespace CommonCodebase.Miscellaneous;

public abstract class LabelBase : VisualObject
{
    protected LabelBase()
    {
        Text = "Placeholder";
    }

    public string Text { get; protected init; }

    protected int CalculateHeight()
    {
        return Text.Split('\n').Length;
    }
}