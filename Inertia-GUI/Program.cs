using CommonCodebase.Engines;
using GUI.Forms.JsonStorage;

namespace GUI;

public static class Program
{
    public static readonly ApplicationContext AppContext = new(new LoginForm());

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        AudioEngine.StartMusicPlaylist();
        OptionsForm.ApplyOptions();
        Application.Run(AppContext);
    }
}