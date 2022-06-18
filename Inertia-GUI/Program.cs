using GUI.Forms;

namespace GUI;

public static class Program
{
    public static readonly ApplicationContext AppContext = new(new MenuForm());

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(AppContext);
    }
}