using MyGame.Core;
using Pastel;
using System.Drawing;

namespace MyGame.Miscellaneous;

public class Score : VisualObject
{
    public const int Width = 32;
    private const int Height = 1;

    private string Text { get; }

    private int CurrentScore { get; set; }

    private int TotalScore { get; set; }

    public Score()
    {
        Text = Resources.Score;

        X = ControlsTip.Width + Map.Width + Width / 2 - Text.Length;
        Y = Map.Height - Height;

        Color = Color.FromArgb(12, 216, 0);
    }

    public delegate void ScoreHandler();

    public override void Draw()
    {
        SetPosition();
        Console.Write(Text + TotalScore.ToString().Pastel(Color));
    }

    public void Update()
    {
        SetPosition(Text.Length);
        Console.Write((TotalScore + ++CurrentScore).ToString().Pastel(Color));
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

    private void SetPosition(int leftMargin = 0)
    {
        Console.SetCursorPosition(X + leftMargin, Y);
    }
}