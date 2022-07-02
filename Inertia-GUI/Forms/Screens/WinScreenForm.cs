using GUI.Forms.Base;

namespace GUI.Forms.Screens;

internal partial class WinScreenForm : ScreenFormBase
{
    public WinScreenForm()
    {
        InitializeComponent();
    }

    private void ContinueButton_Click(object? sender, EventArgs e)
    {
        GameForm gameForm = new();
        gameForm.Continue();
        gameForm.MakeActive();
    }
}