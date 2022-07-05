using CommonCodebase.Core;

namespace CommonCodebase.Labels;

public abstract class LabelBase : VisualObject
{
    protected LabelBase()
    {
        Text = "Placeholder";
    }

    public string Text { get; set; }

    protected int CalculateHeight()
    {
        return Text.Split('\n').Length;
    }
}