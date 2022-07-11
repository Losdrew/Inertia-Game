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
        if (sender is not Button button || _currentCursorType == CursorType.Erase)
        {
            return;
        }

        var bitmapImage = new Bitmap(button.BackgroundImage, button.Size);

        // Change cursor to game element's image
        Cursor = new Cursor(bitmapImage.GetHicon());

        _isGameElementSelected = true;
        _selectedGameElement = (string)button.Tag; // tag has game element's name

        // Update selection status to selected
        ElementSelectionStatusLabel.ForeColor = Color.Green;
        ElementSelectionStatusLabel.Text = Resources.ElementSelectedText;
        ElementSelectionStatusLabel.Location = ElementSelectionStatusLabel.Location with
        {
            X = GraphicsEngine.GetCenteredValue(ActionPanel.Size.Width, ElementSelectionStatusLabel.Size.Width)
        };
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

        // Update selection status to deselected
        ElementSelectionStatusLabel.ForeColor = Color.IndianRed;
        ElementSelectionStatusLabel.Text = Resources.ElementNotSelectedText;
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
                // Create map borders
                if (_currentMap.IsOnBorders(x, y))
                {
                    _currentMap[x, y] = new Wall(x, y);
                    CreateCellPictureBox(x, y, Resources.Wall);
                }

                else
                {
                    _currentMap[x, y] = new Empty(x, y);
                    CreateCellPictureBox(x, y, null);
                }
            }
        }
    }

    private void CreateCellPictureBox(int x, int y, Image? image)
    {
        var cellPictureBox = GraphicsEngine.CreateCellPictureBox(x, y, image, MapPanel);

        cellPictureBox.Tag = (x, y);
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
        if (_currentMap?.PlayerCount == 0)
        {
            MessageBox.Show(
                Resources.PlayerNotPlacedText,
                Resources.PlayerNotPlacedCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        GameForm.StartGame(GameMode.PremadeMaps, _currentMap);
        GameForm.MakeActive();
        SaveMapList();
    }

    private void SaveMapList()
    {
        if (_mapList != null)
        {
            _mapRepository.UpdateMapList(_mapList);
        }
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

        switch (_selectedGameElement)
        {
            // Show error if max player count exceeded
            case "Player" when _currentMap.PlayerCount >= Map.MaxPlayerCount:
                MessageBox.Show(
                    Resources.MaxPlayerCountExceededText + Map.MaxPlayerCount + ".",
                    Resources.MaxPlayerCountExceededCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            case "Player":
                _currentMap[x, y] = new Player(x, y);
                cellPictureBox.Image = Resources.Player_Right;
                break;
            case "Prize":
                _currentMap[x, y] = new Prize(x, y);
                cellPictureBox.Image = Resources.Prize;
                break;
            case "Stop":
                _currentMap[x, y] = new Stop(x, y);
                cellPictureBox.Image = Resources.Stop;
                break;
            case "Trap":
                _currentMap[x, y] = new Trap(x, y);
                cellPictureBox.Image = Resources.Trap;
                break;
            case "Wall":
                _currentMap[x, y] = new Wall(x, y);
                cellPictureBox.Image = Resources.Wall;
                break;
            default:
                _currentMap[x, y] = new Empty(x, y);
                cellPictureBox.Image = Resources.Error;
                break;
        }
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
                var image = map[x, y] switch
                {
                    Player => Resources.Player_Right,
                    Prize => Resources.Prize,
                    Stop => Resources.Stop,
                    Trap => Resources.Trap,
                    Wall => Resources.Wall,
                    _ => null
                };

                CreateCellPictureBox(x, y, image);
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

        _currentMap.Name = MapNameTextBox.Text;

        _mapList?.Add(_currentMap);
        MapListView.Items.Add(_currentMap.Name);
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
        }
    }

    private void MenuButton_SaveMaps_Click(object sender, EventArgs e)
    {
        MenuButton_Click(sender, e);
        SaveMapList();
    }

    private void LevelEditorForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        FormBase_FormClosing(sender, e);
        SaveMapList();
    }
}