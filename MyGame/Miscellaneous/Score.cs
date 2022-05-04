using MyGame.Core;

namespace MyGame.Miscellaneous;

public class Score : VisualObject
{
    private const string ScoreText = "Score: ";

    private int CurrentScore { get; set; }

    private int TotalScore { get; set; }

    public Score()
    {
        Color = ConsoleColor.Green;
    }

    public delegate void ScoreHandler();

    public override void Draw()
    {
        Console.SetCursorPosition(
            Console.WindowWidth - Map.MapWidth,
            Map.MapHeight - 1);

        Console.Write(ScoreText);

        if (TotalScore > 0)
            ApplyColor();

        Console.Write(TotalScore);

        ResetColor();
    }

    public void Update()
    {
        Console.SetCursorPosition(
            Console.WindowWidth - Map.MapWidth + ScoreText.Length,
            Map.MapHeight - 1);

        ApplyColor();

        Console.Write(TotalScore + ++CurrentScore);

        ResetColor();
    }

    public void Save()
    {
        TotalScore += CurrentScore;
        CurrentScore = 0;
    }

    public void ResetAll()
    {
        TotalScore = 0;
        CurrentScore = 0;
    }

    public void ResetCurrent()
    {
        CurrentScore = 0;
    }
}