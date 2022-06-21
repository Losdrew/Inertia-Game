namespace GUI.Forms.Base;

public partial class FormBase : Form
{
    protected FormBase()
    {
        InitializeComponent();
    }

    public void MakeActive()
    {
        Program.AppContext.MainForm?.Hide();
        Program.AppContext.MainForm = this;
        Program.AppContext.MainForm.Show();
    }
}