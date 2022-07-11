using CommonCodebase.Core;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Storage.Objects;
using GUI.Storage.Repositories;
using System.Globalization;

namespace GUI.Forms.JsonStorage;

internal partial class OptionsForm : FormBase
{
    private static readonly OptionsRepository OptionsRepository = new();

    private static Options? _options;

    public OptionsForm()
    {
        InitializeComponent();
        Initialize();
    }

    public static Options Options
    {
        get => _options ??= OptionsRepository.GetOptions();
        private set => _options = value;
    }

    public static void ApplyOptions()
    {
        Options = OptionsRepository.GetOptions();

        ApplyLanguageSettings();
        InputEngine.DirectionControls = Options.DirectionControls.ToDictionary(x => x.Value, x => x.Key);
        InputEngine.MusicControls = Options.MusicControls.ToDictionary(x => x.Value, x => x.Key);
    }

    public static void ApplyLanguageSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Options.Language);
    }

    private void Initialize()
    {
        Options = OptionsRepository.GetOptions();

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
        UpdateCurrentOptions();
        OptionsRepository.UpdateOptions(Options);
        ReloadForm();
        ApplyOptions();
    }

    private void UpdateCurrentOptions()
    {
        Options.MapSize = ((int)MapWidth.Value, (int)MapHeight.Value);

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
        ApplyLanguageSettings();
        Controls.Clear();
        InitializeComponent();
        Initialize();
    }
}