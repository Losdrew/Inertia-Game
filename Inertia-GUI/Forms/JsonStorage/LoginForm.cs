using GUI.Forms.Base;
using GUI.Forms.Screens;
using GUI.Storage.Objects;

namespace GUI.Forms.JsonStorage;

internal partial class LoginForm : FormBase
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        GameForm.User = new User(NameTextBox.Text);
        new MenuScreenForm().MakeActive();
    }

    private void EnterAnonymouslyButton_Click(object sender, EventArgs e)
    {
        GameForm.User = new User();
        new MenuScreenForm().MakeActive();
    }
}