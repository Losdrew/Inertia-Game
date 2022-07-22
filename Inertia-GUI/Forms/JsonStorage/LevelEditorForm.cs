using CommonCodebase.Core;
using CommonCodebase.Entities;
using GUI.Engines;
using GUI.Forms.Base;
using GUI.Properties;
using GUI.Storage.Repositories;

namespace GUI.Forms.JsonStorage;

internal partial class LevelEditorForm : FormBase
{
    private Map? _currentMap;

    private readonly List<Map>? _mapList;
    private readonly MapRepository _mapRepository = new();

    private CursorType _currentCursorType;

    private bool _isGameElementSelected;
    private string? _selectedGameElement;

    public LevelEditorForm()
    {
        InitializeComponent();

        _mapList = _mapRepository.GetAllMaps() ?? new List<Map>();

        // Fill list of maps with maps saved in json
        foreach (var map in _mapList)
        {
            MapListView.Items.Add(map.Name);
        }
    }

    private enum CursorType
    {
        Select,
        Erase
    }

    private void GameElement_Select(object sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        _currentCursorType = CursorType.Select;

        var bitmapImage = new Bitmap(button.BackgroundImage, button.Size);

        // Change cursor to game element's image
        Cursor = new Cursor(bitmapImage.GetHicon());

        _isGameElementSelected = true;
        _selectedGameElement = (string)button.Tag; // tag has game element's name

        ChangeElementSelectionStatus(Color.Green, Resources.ElementSelectedText);
    }

    private void GameElement_Deselect(object sender, EventArgs e)
    {
        if (!_isGameElementSelected)
        {
            return;
        }

        Cursor = DefaultCursor;

        _isGameElementSelected = false;
        _selectedGameElement = null;

        ChangeElementSelectionStatus(Color.IndianRed, Resources.ElementNotSelectedText);
    }

    private void ChangeElementSelectionStatus(Color color, string text)
    {
        ElementSelectionStatusLabel.ForeColor = color;
        ElementSelectionStatusLabel.Text = text;
        ElementSelectionStatusLabel.Location = ElementSelectionStatusLabel.Location with
        {
            X = GraphicsEngine.GetCenteredValue(ActionPanel.Size.Width, ElementSelectionStatusLabel.Size.Width)
        };
    }

    private void SelectCursorButton_Click(object sender, EventArgs e)
    {
        Cursor = DefaultCursor;
        _currentCursorType = CursorType.Select;
    }

    private void EraseCursorButton_Click(object sender, EventArgs e)
    {
        var bitmapImage = new Bitmap(Resources.EraseCursor, DefaultCursor.Size);
        Cursor = new Cursor(bitmapImage.GetHicon());
        _currentCursorType = CursorType.Erase;
    }

    private void CreateMapTemplateButton_Click(object sender, EventArgs e)
    {
        // Clear previous template
        MapPanel.Controls.Clear();

        var (width, height) = ((int)MapWidth.Value, (int)MapHeight.Value);

        _currentMap = new Map(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                _currentMap[x, y] = _currentMap.IsOnBorders(x, y) ? new Wall(x, y) : new Empty(x, y);
                CreateCellPictureBox(_currentMap[x, y]);
            }
        }
    }

    private void CreateCellPictureBox(CellBase? cell)
    {
        if (cell is null)
        {
            return;
        }

        var cellPictureBox = GraphicsEngine.CreateCellPictureBox(cell, MapPanel);

        cellPictureBox.Tag = (cell.X, cell.Y);
        cellPictureBox.Enabled = true;
        cellPictureBox.BorderStyle = BorderStyle.FixedSingle;
        cellPictureBox.MouseClick += CellPictureBox_MouseClick;

        MapPanel.Controls.Add(cellPictureBox);
    }

    private void ClearMapTemplateButton_Click(object sender, EventArgs e)
    {
        MapPanel.Controls.Clear();
        _currentMap = null;
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
        // Must not start if no player is placed on map
        if (_currentMap?.PlayerCount == 0)
        {
            MessageBox.Show(
                Resources.NoPlayerPlacedText,
                Resources.NoPlayerPlacedCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        // Must not start if no prize is placed on map
        if (_currentMap?.PrizeCount == 0)
        {
            MessageBox.Show(
                Resources.NoPrizePlacedText,
                Resources.NoPrizePlacedCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        GameForm.StartGame(_currentMap);
        GameForm.MakeActive();
        SaveMapList();
    }

    private void CellPictureBox_MouseClick(object? sender, MouseEventArgs e)
    {
        if (sender is not PictureBox cellPictureBox || _currentMap is null)
        {
            return;
        }

        // Get unscaled coordinates of cellPictureBox
        var (x, y) = (ValueTuple<int, int>)cellPictureBox.Tag;

        // Map borders must not be replaced or removed
        if (_currentMap.IsOnBorders(x, y))
        {
            return;
        }

        switch (_currentCursorType)
        {
            case CursorType.Select:
                AddGameElementToPictureBox(x, y, cellPictureBox);
                break;
            case CursorType.Erase:
                RemoveGameElementFromPictureBox(x, y, cellPictureBox);
                break;
        }
    }

    private void AddGameElementToPictureBox(int x, int y, PictureBox cellPictureBox)
    {
        if (!_isGameElementSelected || _currentMap is null)
        {
            return;
        }

        // Show error if max player count exceeded
        if (_selectedGameElement == "Player" && _currentMap.PlayerCount >= Map.MaxPlayerCount)
        {
            MessageBox.Show(
                Resources.MaxPlayerCountExceededText + Map.MaxPlayerCount + ".",
                Resources.MaxPlayerCountExceededCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        _currentMap[x, y] = _selectedGameElement switch
        {
            "Player" => new Player(x, y),
            "Prize" => new Prize(x, y),
            "Stop" => new Stop(x, y),
            "Trap" => new Trap(x, y),
            "Wall" => new Wall(x, y),
            _ => new Empty(x, y)
        };

        cellPictureBox.Image = GraphicsEngine.GetCellImage(_currentMap[x, y]);
    }

    private void RemoveGameElementFromPictureBox(int x, int y, PictureBox cellPictureBox)
    {
        if (_currentMap is null)
        {
            return;
        }

        cellPictureBox.Image = null;
        _currentMap[x, y] = new Empty(x, y);
    }

    private void MapListView_DoubleClick(object sender, MouseEventArgs e)
    {
        var info = MapListView.HitTest(e.X, e.Y);
        var item = info.Item;

        if (_mapList is null || item is null)
        {
            return;
        }

        LoadMap(_mapList.Find(map => map.Name == item.Text));
    }

    private void LoadMap(Map? map)
    {
        if (map is null)
        {
            return;
        }

        MapPanel.Controls.Clear();

        for (var y = 0; y < map.Size.Height; y++)
        {
            for (var x = 0; x < map.Size.Width; x++)
            {
                CreateCellPictureBox(map[x, y]);
            }
        }

        _currentMap = map;
    }

    private void AddMapButton_Click(object sender, EventArgs e)
    {
        if (_currentMap is null || _mapList is null || MapNameTextBox.Text == "")
        {
            return;
        }

        // Show error if map list contains a map with the same name entered
        if (_mapList.Any(map => map.Name == MapNameTextBox.Text))
        {
            MessageBox.Show(
                Resources.ListContainsMapWithSameNameText,
                Resources.ListContainsMapWithSameNameCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        var currentMapCopy = new Map(_currentMap)
        {
            Name = MapNameTextBox.Text
        };

        _mapList?.Add(currentMapCopy);
        MapListView.Items.Add(currentMapCopy.Name);
    }

    private void DeleteMapButton_Click(object sender, EventArgs e)
    {
        if (MapListView.SelectedItems.Count == 0)
        {
            return;
        }

        foreach (ListViewItem item in MapListView.SelectedItems)
        {
            MapListView.Items.Remove(item);

            var mapItem = _mapList?.Find(map => map.Name == item.Text);
            
            if (mapItem != null)
            {
                _mapList?.Remove(mapItem);
            }
        }
    }

    private void MenuButton_SaveMaps_Click(object sender, EventArgs e)
    {
        if (IsDiscardingCurrentMap())
        {
            SaveMapList();
            MenuButton_Click(sender, e);
        }
    }

    private void LevelEditorForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (IsDiscardingCurrentMap())
        {
            SaveMapList();
            FormBase_FormClosing(sender, e);
        }
    }

    private bool IsDiscardingCurrentMap()
    {
        if (_mapList is null || _currentMap is null || _mapList.Any(map => map.IsEqual(_currentMap)))
        {
            return true;
        }

        if (MessageBox.Show(
                Resources.ExitWithoutSavingCurrentMap,
                Resources.ExitMessageBoxCaption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
        {
            return true;
        }

        return false;
    }

    private void SaveMapList()
    {
        if (_mapList != null)
        {
            _mapRepository.UpdateMapList(_mapList);
        }
    }
}