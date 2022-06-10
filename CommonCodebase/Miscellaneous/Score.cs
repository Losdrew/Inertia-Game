using System.Drawing;
using CommonCodebase.Core;

namespace CommonCodebase.Miscellaneous;

public class Score : VisualObject
{
    public const int Width = 32;
    private const int Height = 1;

    public string Text { get; }

    public int CurrentScore { get; set; }

    public int TotalScore { get; private set; }

    public Score()
    {
        Text = Resources.Score;

        X = ControlsTip.Width + Map.Width + Width / 2 - Text.Length / 2;
        Y = Map.Height - Height;

        Color = Color.FromArgb(12, 216, 0);
    }

    public static event EventHandler? DrawScore;
    public static event EventHandler? UpdateScore;

    public override void Draw()
    {
        DrawScore?.Invoke(this, EventArgs.Empty);
    }

    public void Update(object? sender, EventArgs e)
    {
        UpdateScore?.Invoke(this, EventArgs.Empty);
    }

    public void Save()
    {
        TotalScore += CurrentScore;
        ResetCurrent();
    }

    public void ResetAll()
    {
        TotalScore = 0;
        ResetCurrent();
    }

    public void ResetCurrent()
    {
        CurrentScore = 0;
    }
}