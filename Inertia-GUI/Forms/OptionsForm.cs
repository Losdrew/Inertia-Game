using CommonCodebase.Core;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Miscellaneous;
using System.Globalization;

namespace GUI.Forms;

internal partial class OptionsForm : FormBase
{
    public static Options? Options;

    private static readonly OptionsRepository OptionsRepository = new();

    public OptionsForm()
    {
        InitializeComponent();
        Initialize();
    }

    public static void ApplyOptions()
    {
        var options = OptionsRepository.GetOptions();

        if (options.MapSize == (0, 0) || 
            options.DirectionControls is null || 
            options.MusicControls is null || 
            options.Language is null)
        {
            return;
        }

        Map.Size = options.MapSize;
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(options.Language);
        InputEngine.DirectionControls = options.DirectionControls.ToDictionary(x => x.Value, x => x.Key);
        InputEngine.MusicControls = options.MusicControls.ToDictionary(x => x.Value, x => x.Key);
    }

    private void Initialize()
    {
        Options = OptionsRepository.GetOptions();

        if (Options.MapSize == (0, 0) || 
            Options.DirectionControls is null || 
            Options.MusicControls is null || 
            Options.Language is null)
        {
            return;
        }

        MapWidth.Value = Options.MapSize.Width;
        MapHeight.Value = Options.MapSize.Height;

        foreach (var comboBox in ControlsContainer.Panel2.Controls.OfType<ComboBox>())
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DataSource = Enum.GetValues<Keys>();

            if (comboBox.Tag is Direction direction)
            {
                comboBox.SelectedItem = Options.DirectionControls[direction];
            }

            if (comboBox.Tag is Music music)
            {
                comboBox.SelectedItem = Options.MusicControls[music];
            }
        }

        EnglishRadioButton.Checked = Options.Language == "en-US";
        UkrainianRadioButton.Checked = Options.Language == "uk-UA";
    }

    private void SaveSettingsButton_Click(object sender, EventArgs e)
    {
        if (Options is null)
        {
            return;
        }

        UpdateCurrentOptions();

        OptionsRepository.UpdateOptions(Options);

        ReloadForm();

        ApplyOptions();
    }

    private void UpdateCurrentOptions()
    {
        if (Options is null)
        {
            return;
        }

        Options.MapSize = ((int)MapWidth.Value, (int)MapHeight.Value);

        Options.DirectionControls ??= new Dictionary<Direction, Keys>();
        Options.MusicControls ??= new Dictionary<Music, Keys>();

        foreach (var comboBox in ControlsContainer.Panel2.Controls.OfType<ComboBox>())
        {
            if (comboBox.Tag is Direction direction)
            {
                Options.DirectionControls[direction] = (Keys)comboBox.SelectedItem;
            }

            if (comboBox.Tag is Music music)
            {
                Options.MusicControls[music] = (Keys)comboBox.SelectedItem;
            }
        }

        Options.Language = EnglishRadioButton.Checked ? "en-US" : "uk-UA";
    }

    private void ReloadForm()
    {
        if (Options?.Language is null)
        {
            return;
        }

        ApplyLanguageSettings();
        Controls.Clear();
        InitializeComponent();
        Initialize();
    }
}