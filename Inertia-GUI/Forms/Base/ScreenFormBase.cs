namespace GUI.Forms.Base;

public partial class ScreenFormBase : FormBase
{
    protected static readonly GameForm GameForm = new();

    protected ScreenFormBase()
    {
        InitializeComponent();
    }

    protected void RestartLevelButton_Click(object? sender, EventArgs e)
    {
        GameForm.Restart();
        GameForm.MakeActive();
    }

    protected void QuitButton_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}