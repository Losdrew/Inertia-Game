using GUI.Forms.Base;

namespace GUI.Forms.Screens;

internal partial class GameOverScreenForm : ScreenFormBase
{
    public GameOverScreenForm()
    {
        InitializeComponent();
    }

    private void CreateNewLevelButton_Click(object? sender, EventArgs e)
    {
        GameForm gameForm = new();
        gameForm.CreateNew();
        gameForm.MakeActive();
    }
}