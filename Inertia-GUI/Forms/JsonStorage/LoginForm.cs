using GUI.Forms.Base;
using GUI.Forms.Screens;

namespace GUI.Forms.JsonStorage;

internal partial class LoginForm : FormBase
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        GameForm.User.Name = NameTextBox.Text;
        new MenuScreenForm().MakeActive();
    }

    private void EnterAnonymouslyButton_Click(object sender, EventArgs e)
    {
        new MenuScreenForm().MakeActive();
    }
}