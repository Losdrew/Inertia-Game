using CommonCodebase.Core;

namespace CommonCodebase.Labels;

public abstract class LabelBase : VisualObject
{
    private string _text = "Placeholder";

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            Height = Text.Split('\n').Length;
        }
    }

    public int Height { get; private set; }
}