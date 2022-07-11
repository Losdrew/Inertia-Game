using GUI.Forms.Base;
using GUI.Forms.JsonStorage;

namespace GUI.Forms.Screens;

internal partial class MenuScreenForm : ScreenFormBase
{
    public MenuScreenForm()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        GameForm.StartGame(GameMode.RandomMaps);
        GameForm.MakeActive();
    }

    private void LevelEditorButton_Click(object sender, EventArgs e)
    {
        new LevelEditorForm().MakeActive();
    }

    private void OptionsButton_Click(object? sender, EventArgs e)
    {
        new OptionsForm().MakeActive();
    }

    private void LeaderboardsButton_Click(object sender, EventArgs e)
    {
        new LeaderboardsForm().MakeActive();
    }

    private void QuitButton_Click(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}