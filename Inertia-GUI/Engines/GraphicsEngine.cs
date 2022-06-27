using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Forms;
using GUI.Properties;

namespace GUI.Engines;

internal static class GraphicsEngine
{
    private const int CellWidthScale = 45;
    private const int CellHeightScale = 45;

    private static GameForm? _gameForm;

    public static void GetGameForm(GameForm gameForm)
    {
        _gameForm = gameForm;
    }

    public static void SetMapBox()
    {
        if (_gameForm is null)
        {
            return;
        }

        var (width, height) = GetScaledValues(Map.Width, Map.Height);

        _gameForm.MapBox.Size = new Size(width, height);

        // Clearing all controls to draw on an empty MapBox
        _gameForm.MapBox.Controls.Clear();
    }

    public static (int first, int second) GetScaledValues(int first = 1, int second = 1)
    {
        return (first * CellWidthScale, second * CellHeightScale);
    }

    public static void DrawCell(object? sender, EventArgs e)
    {
        // Don't draw if cell is an empty one
        if (sender is not CellBase cell || cell is Empty || _gameForm is null)
        {
            return;
        }

        var image = cell switch
        {
            Player => Resources.PlayerAnimated,
            Prize => Resources.Prize,
            Stop => Resources.Stop,
            Trap => Resources.Trap,
            Wall => Resources.Wall,
            _ => Resources.Error
        };

        var (width, height) = GetScaledValues();
        var (x, y) = GetScaledValues(cell.X, cell.Y);

        var cellPictureBox = new PictureBox
        {
            Image = image,
            Enabled = false,
            Parent = _gameForm.MapBox,
            Location = new Point(x, y),
            BackColor = Color.Transparent,
            Size = new Size(width, height),
            SizeMode = PictureBoxSizeMode.Zoom,
        };

        if (cell is Player)
        {
            AnimationEngine.IsPlayerMirrored = false;
            AnimationEngine.PlayerPictureBox = cellPictureBox;
        }

        _gameForm.MapBox.Controls.Add(cellPictureBox);
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell || _gameForm is null)
        {
            return;
        }

        var (x, y) = GetScaledValues(cell.X, cell.Y);

        var cellPictureBox = FindPictureBoxOnMap(new Point(x, y));

        if (cellPictureBox != null)
        {
            ClearPictureBoxOnMap(cellPictureBox);
        }
    }

    public static void DrawControlsTip(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip || _gameForm is null)
        {
            return;
        }

        _gameForm.ControlsTipLabel.Text = controlsTip.Text;

        var sectionSize = _gameForm.LeftSection.Size;
        var tipSize = _gameForm.ControlsTipLabel.Size;

        _gameForm.ControlsTipLabel.Location = GetCenteredLocation(sectionSize, tipSize);
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || _gameForm is null)
        {
            return;
        }

        _gameForm.ScoreLabel.Text = score.Text;
        _gameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();

        var sectionSize = _gameForm.RightSection.Size;
        var boxSize = _gameForm.ScoreBox.Size;

        _gameForm.ScoreBox.Location = GetCenteredLocation(sectionSize, boxSize);
    }

    public static void UpdateScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || _gameForm is null)
        {
            return;
        }

        _gameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();
    }

    public static PictureBox? FindPictureBoxOnMap(Point pictureBoxLocation)
    {
        if (_gameForm != null)
        {
            foreach (Control control in _gameForm.MapBox.Controls)
            {
                if (control.Location == pictureBoxLocation)
                {
                    return control as PictureBox;
                }
            }
        }

        return null;
    }

    public static void ClearPictureBoxOnMap(PictureBox? pictureBox)
    {
        if (pictureBox == AnimationEngine.PlayerPictureBox || pictureBox is null || _gameForm is null)
        {
            return;
        }

        _gameForm.MapBox.Controls.Remove(pictureBox);
    }

    private static Point GetCenteredLocation(Size parentSize, Size childSize)
    {
        var x = (parentSize.Width - childSize.Width) / 2;
        var y = (parentSize.Height - childSize.Height) / 2;

        return new Point(x, y);
    }
}