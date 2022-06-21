using GUI.Forms.Base;

namespace GUI.Forms.Screens;

public partial class GameOverScreenForm : ScreenFormBase
{
    public GameOverScreenForm()
    {
        InitializeComponent();
    }

    private void CreateNewLevelButton_Click(object? sender, EventArgs e)
    {
        GameForm.CreateNew();
        GameForm.MakeActive();
    }
}