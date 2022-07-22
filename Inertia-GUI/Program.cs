using CommonCodebase.Engines;
using GUI.Forms.JsonStorage;
using GUI.Storage.Services;

namespace GUI;

public static class Program
{
    public static readonly ApplicationContext AppContext = new(new LoginForm());

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        AudioEngine.StartMusicPlaylist();
        OptionsService.ApplyOptions();
        Application.Run(AppContext);
    }
}