using CommonCodebase.Core;
using CommonCodebase.Engines;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Engines;

namespace GUI.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        ControlsTip controlsTip = new();
        Map map = new();
        Score score = new();

        SetTargetMethods();

        AudioEngine.StartMusicPlaylist();

        map = new Map();
        map.CreateMap();

        // Create a copy of map
        Map currentMap = new(map);

        GraphicsEngine.MainForm = this;
        GraphicsEngine.SetMapBoxSize();

        currentMap.Draw();
        controlsTip.Draw();
        score.Draw();

        currentMap.UpdateScore += score.Update;
    }

    private void SetTargetMethods()
    {
        CellBase.DrawCell += GraphicsEngine.DrawCell;
        Score.DrawScore += GraphicsEngine.DrawScore;
        Score.UpdateScore += GraphicsEngine.UpdateScore;
        ControlsTip.DrawControlsTip += GraphicsEngine.DrawControls;
        //MovementEngine.GetMovementInput += InputEngine.GetInput<Direction>;
        //ScreenBase.GetScreenInput += InputEngine.GetInput<ConsoleKey>;
    }
}