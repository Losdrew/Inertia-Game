using GUI.Engines;
using GUI.Forms.JsonStorage;
using GUI.Forms.Screens;
using GUI.Properties;
using System.Globalization;

namespace GUI.Forms.Base;

internal partial class FormBase : Form
{
    protected FormBase()
    {
        ApplyLanguageSettings();
        KeyPreview = true;
        KeyDown += InputEngine.ReadKey;
        InputEngine.AllowedInput = InputType.MusicInput;
    }

    public void MakeActive()
    {
        Program.AppContext.MainForm?.Hide();
        Program.AppContext.MainForm = this;
        Program.AppContext.MainForm.Show();
    }

    protected static void ApplyLanguageSettings()
    {
        if (OptionsForm.Options?.Language is null)
        {
            return;
        }

        Thread.CurrentThread.CurrentUICulture = new CultureInfo(OptionsForm.Options.Language);
    }

    protected void MenuButton_Click(object sender, EventArgs e)
    {
        new MenuScreenForm().MakeActive();
    }

    protected void MenuButton_Click_ProgressSave(object sender, EventArgs e)
    {
        if (GameForm.IsEndingGameSession())
        {
            MenuButton_Click(sender, EventArgs.Empty);
            GameForm.SaveUserInfo();
        }
    }

    protected void FormBase_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(
                Resources.ExitMessageBoxText,
                Resources.ExitMessageBoxCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}