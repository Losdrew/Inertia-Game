using GUI.Forms.Base;

namespace GUI.Forms.Screens;

public partial class WinScreenForm : ScreenFormBase
{
    public WinScreenForm()
    {
        InitializeComponent();
    }

    private void ContinueButton_Click(object? sender, EventArgs e)
    {
        GameForm.Continue();
        GameForm.MakeActive();
    }
}