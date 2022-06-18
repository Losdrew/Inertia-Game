namespace GUI.Forms;

public partial class GameOverForm : Form
{
    public GameOverForm()
    {
        InitializeComponent();
    }

    private void QuitButton_Click(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}