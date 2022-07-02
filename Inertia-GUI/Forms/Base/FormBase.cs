using System.Globalization;
using GUI.Engines;
using GUI.Forms.Screens;
using GUI.Properties;

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

    protected void MenuButton_Click(object sender, EventArgs e)
    {
        new MenuScreenForm().MakeActive();
    }

    protected void FormBase_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(
                Resources.ExitMessageBoxText,
                Resources.ExitMessageBoxCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

    protected static void ApplyLanguageSettings()
    {
        if (OptionsForm.Options?.Language is null)
        {
            return;
        }

        Thread.CurrentThread.CurrentUICulture = new CultureInfo(OptionsForm.Options.Language);
    }
}