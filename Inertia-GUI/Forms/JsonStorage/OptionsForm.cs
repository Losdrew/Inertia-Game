using CommonCodebase.Core;
using GUI.Forms.Base;
using GUI.Properties;
using GUI.Storage.Objects;
using GUI.Storage.Services;

namespace GUI.Forms.JsonStorage;

internal partial class OptionsForm : FormBase
{
    private Options? _options;

    private Options Options
    {
        get => _options ??= OptionsService.GetOptions();
    }

    public OptionsForm()
    {
        InitializeComponent();
        Initialize();
    }

    private void Initialize()
    {
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
        if (!AreControlsValid())
        {
            return;
        }

        UpdateCurrentOptions();
        OptionsService.UpdateOptions(Options);
        OptionsService.ApplyOptions();
        ReloadForm();
    }

    private bool AreControlsValid()
    {
        var selectedItems = new List<Keys>();

        foreach (var comboBox in ControlsContainer.Panel2.Controls.OfType<ComboBox>())
        {
            selectedItems.Add((Keys)comboBox.SelectedItem);
        }

        if (selectedItems.Distinct().Count() < selectedItems.Count)
        {
            MessageBox.Show(
                Resources.CannotAssignMultipleKeysText,
                Resources.CannotAssignMultipleKeysCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }

        return true;
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
        Controls.Clear();
        InitializeComponent();
        Initialize();
    }
}