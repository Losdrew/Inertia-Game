using GUI.Forms.Base;

namespace GUI.Forms.Screens;

internal partial class MenuScreenForm : ScreenFormBase
{
    public MenuScreenForm()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        GameForm gameForm = new();
        gameForm.StartGame();
        gameForm.MakeActive();
    }

    private void OptionsButton_Click(object? sender, EventArgs e)
    {
        new OptionsForm().MakeActive();
    }

    private void QuitButton_Click(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}