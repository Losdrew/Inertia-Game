using MyGame.Core;
using Pastel;
using System.Drawing;

namespace MyGame.Miscellaneous;

public class Score : VisualObject
{
    private readonly string _scoreText;

    private int CurrentScore { get; set; }

    private int TotalScore { get; set; }

    public Score()
    {
        _scoreText = "Score: ";
        Color = Color.FromArgb(12, 216, 0);
    }

    public delegate void ScoreHandler();

    public override void Draw()
    {
        SetPosition();
        Console.Write(_scoreText + TotalScore.ToString().Pastel(Color));
    }

    public void Update()
    {
        SetPosition(_scoreText.Length);
        Console.Write((TotalScore + ++CurrentScore).ToString().Pastel(Color));
    }

    private void SetPosition(int leftMargin = 0, int topMargin = 0)
    {
        Console.SetCursorPosition(
            Console.WindowWidth - Map.MapWidth + leftMargin,
            Map.MapHeight - 1 + topMargin);
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