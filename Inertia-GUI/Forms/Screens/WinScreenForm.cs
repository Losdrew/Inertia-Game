using GUI.Forms.Base;
using GUI.Forms.JsonStorage;

namespace GUI.Forms.Screens;

internal partial class WinScreenForm : ScreenFormBase
{
    public WinScreenForm()
    {
        InitializeComponent();
    }

    private void ContinueButton_Click(object? sender, EventArgs e)
    {
        if (GameForm.CurrentGameMode == GameMode.RandomMaps)
        {
            GameForm.Continue();
            GameForm.MakeActive();
        }

        if (GameForm.CurrentGameMode == GameMode.PremadeMaps)
        {
            GameForm.ResetCurrentScore();
            new LevelEditorForm().MakeActive();
        }
    }
}