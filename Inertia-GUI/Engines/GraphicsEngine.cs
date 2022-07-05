using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Labels;
using GUI.Forms;
using GUI.Properties;

namespace GUI.Engines;

internal static class GraphicsEngine
{
    private const int CellWidthScale = 45;
    private const int CellHeightScale = 45;

    public static GameForm? GameForm { private get; set; }

    public static void SetMapBox()
    {
        if (GameForm is null)
        {
            return;
        }

        var (width, height) = GetScaledValues(Map.Size.Width, Map.Size.Height);

        GameForm.MapBox.Size = new Size(width, height);

        // Clearing all controls to draw on an empty MapBox
        GameForm.MapBox.Controls.Clear();
    }

    public static (int first, int second) GetScaledValues(int first = 1, int second = 1)
    {
        return (first * CellWidthScale, second * CellHeightScale);
    }

    public static void DrawCell(object? sender, EventArgs e)
    {
        // Don't draw if cell is an empty one
        if (sender is not CellBase cell || cell is Empty || GameForm is null)
        {
            return;
        }

        var image = cell switch
        {
            Player => Resources.Player_Right,
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
            Parent = GameForm.MapBox,
            Location = new Point(x, y),
            BackColor = Color.Transparent,
            Size = new Size(width, height),
            SizeMode = PictureBoxSizeMode.Zoom
        };

        if (cell is Player)
        {
            AnimationEngine.IsPlayerFacingRight = true;
            AnimationEngine.PlayerPictureBox = cellPictureBox;
        }

        GameForm.MapBox.Controls.Add(cellPictureBox);
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell || GameForm is null)
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
        if (sender is not ControlsTip controlsTip || GameForm is null)
        {
            return;
        }

        if (InputEngine.DirectionControls is null || InputEngine.MusicControls is null)
        {
            return;
        }

        var directionKeys = InputEngine.DirectionControls.Keys.ToList();
        var musicKeys = InputEngine.MusicControls.Keys.ToList();

        var controlsKeys = directionKeys.Concat(musicKeys).ToList();
        var controls = GameForm.ControlsTipLabel.Text;

        // Replace numbers in controls tip template with corresponding keys
        for (var i = 0; controls.Contains(i.ToString()); i++)
        {
            controls = controls.Replace(i.ToString(), controlsKeys[i].ToString());
        }

        GameForm.ControlsTipLabel.Text = controls;

        var sectionSize = GameForm.LeftSection.Size;
        var tipSize = GameForm.ControlsTipLabel.Size;

        GameForm.ControlsTipLabel.Location = GetCenteredLocation(sectionSize, tipSize);
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || GameForm is null)
        {
            return;
        }

        GameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();

        var sectionSize = GameForm.RightSection.Size;
        var boxSize = GameForm.ScoreBox.Size;

        GameForm.ScoreBox.Location = GetCenteredLocation(sectionSize, boxSize);
    }

    public static void UpdateScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || GameForm is null)
        {
            return;
        }

        GameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();
    }

    public static PictureBox? FindPictureBoxOnMap(Point pictureBoxLocation)
    {
        if (GameForm != null)
        {
            foreach (Control control in GameForm.MapBox.Controls)
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
        if (pictureBox == AnimationEngine.PlayerPictureBox || pictureBox is null || GameForm is null)
        {
            return;
        }

        GameForm.MapBox.Controls.Remove(pictureBox);
    }

    private static Point GetCenteredLocation(Size parentSize, Size childSize)
    {
        var x = (parentSize.Width - childSize.Width) / 2;
        var y = (parentSize.Height - childSize.Height) / 2;

        return new Point(x, y);
    }
}