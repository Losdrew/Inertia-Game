using CommonCodebase.Engines;
using GUI.Forms.Base;

namespace GUI.Forms.Screens;

public partial class MenuScreenForm : ScreenFormBase
{
    public MenuScreenForm()
    {
        InitializeComponent();

        AudioEngine.StartMusicPlaylist();
    }

    private void StartButton_Click(object? sender, EventArgs e)
    {
        GameForm.StartGame();
        GameForm.MakeActive();
    }
}