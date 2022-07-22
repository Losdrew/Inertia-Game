using GUI.Engines;
using GUI.Forms.Screens;
using GUI.Properties;
using GUI.Storage.Services;

namespace GUI.Forms.Base;

internal partial class FormBase : Form
{
    protected static readonly GameForm GameForm = new();

    private InputType _previousInputType;

    protected FormBase()
    {
        KeyPreview = true;
        KeyDown += InputEngine.ReadKey;
        InputEngine.AllowedInput = InputType.MusicInput;
        OptionsService.ApplyLanguageSettings();
    }

    public void MakeActive()
    {
        Program.AppContext.MainForm?.Hide();
        Program.AppContext.MainForm = this;
        Program.AppContext.MainForm.Show();
    }

    protected void TextBox_FocusEnter(object sender, EventArgs e)
    {
        // Save previous input type
        _previousInputType = InputEngine.AllowedInput;

        // Disable any third party input 
        InputEngine.AllowedInput = 0;
    }

    protected void TextBox_FocusLeave(object sender, EventArgs e)
    {
        // Restore previous input
        InputEngine.AllowedInput = _previousInputType;
    }

    protected void MenuButton_Click(object sender, EventArgs e)
    {
        new MenuScreenForm().MakeActive();
    }

    protected void MenuButton_Click_SaveProgress(object sender, EventArgs e)
    {
        if (!GameForm.IsEndingGameSession())
        {
            return;
        }

        GameForm.SaveUserInfo();
        MenuButton_Click(sender, EventArgs.Empty);
    }

    protected void FormBase_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(
                Resources.ExitMessageBoxText,
                Resources.ExitMessageBoxCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
        {
            Environment.Exit(0);
        }

        e.Cancel = true;
    }
}