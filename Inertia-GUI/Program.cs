using CommonCodebase.Engines;
using GUI.Forms;
using GUI.Forms.Screens;

namespace GUI;

public static class Program
{
    public static readonly ApplicationContext AppContext = new(new MenuScreenForm());

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        AudioEngine.StartMusicPlaylist();
        OptionsForm.ApplyOptions();
        Application.Run(AppContext);
    }
}