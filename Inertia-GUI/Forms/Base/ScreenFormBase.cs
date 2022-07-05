namespace GUI.Forms.Base;

internal partial class ScreenFormBase : FormBase
{
    protected static readonly GameForm GameForm = new();

    protected void RestartLevelButton_Click(object? sender, EventArgs e)
    {
        GameForm.Restart();
        GameForm.MakeActive();
    }
}