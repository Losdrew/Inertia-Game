namespace GUI.Forms;

public partial class WinForm : Form
{
    public WinForm()
    {
        InitializeComponent();
    }

    private void QuitButton_Click(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}