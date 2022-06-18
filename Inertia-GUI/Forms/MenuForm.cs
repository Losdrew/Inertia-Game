namespace GUI.Forms;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        MainForm mainForm = new();
        Program.AppContext.MainForm = mainForm;
        Close();
        mainForm.Show();
    }

    private void QuitButton_Click(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}