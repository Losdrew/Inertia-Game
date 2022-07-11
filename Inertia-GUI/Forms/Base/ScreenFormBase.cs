namespace GUI.Forms.Base;

internal partial class ScreenFormBase : FormBase
{
    protected void RestartLevelButton_Click(object? sender, EventArgs e)
    {
        GameForm.Restart();
        GameForm.MakeActive();
    }
}