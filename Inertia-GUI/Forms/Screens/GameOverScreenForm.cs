using GUI.Forms.Base;
using GUI.Forms.JsonStorage;

namespace GUI.Forms.Screens;

internal partial class GameOverScreenForm : ScreenFormBase
{
    public GameOverScreenForm()
    {
        InitializeComponent();
    }

    private void CreateNewLevelButton_Click(object? sender, EventArgs e)
    {
        if (GameForm.CurrentGameMode == GameMode.RandomMaps)
        {
            if (GameForm.IsEndingGameSession())
            {
                GameForm.CreateNew();
                GameForm.MakeActive();
            }
        }

        if (GameForm.CurrentGameMode == GameMode.PremadeMaps)
        {
            GameForm.ResetCurrentScore();
            new LevelEditorForm().MakeActive();
        }
    }
}