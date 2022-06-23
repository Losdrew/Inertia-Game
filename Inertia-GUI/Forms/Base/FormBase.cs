using CommonCodebase.Core;
using GUI.Engines;

namespace GUI.Forms.Base;

public partial class FormBase : Form
{
    protected FormBase()
    {
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

    protected void FormBase_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(
                "Are you sure you want to exit?",
                "Inertia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}