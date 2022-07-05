using GUI.Engines;
using GUI.Forms.Base;
using GUI.Forms.Screens;

namespace GUI.Forms.JsonStorage;

internal partial class LoginForm : FormBase
{
    private InputType _previousInputType;

    public LoginForm()
    {
        InitializeComponent();
    }

    private void TextBox_FocusEnter(object sender, EventArgs e)
    {
        // Save previous input type
        _previousInputType = InputEngine.AllowedInput;

        // Disable any third party input 
        InputEngine.AllowedInput = 0;
    }

    private void TextBox_FocusLeave(object sender, EventArgs e)
    {
        // Restore previous input
        InputEngine.AllowedInput = _previousInputType;
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
