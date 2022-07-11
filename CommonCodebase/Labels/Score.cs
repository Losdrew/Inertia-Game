namespace CommonCodebase.Labels;

public class Score : LabelBase
{
    public int ScoreToDraw { get; private set; }

    public int TotalScore { get; private set; }

    private int CurrentScore { get; set; }

    public static event EventHandler? DrawScore;
    public static event EventHandler? UpdateScore;

    public override void Draw()
    {
        ScoreToDraw = TotalScore;
        DrawScore?.Invoke(this, EventArgs.Empty);
    }

    public void Update()
    {
        ScoreToDraw = TotalScore + ++CurrentScore;
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