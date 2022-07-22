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

    public static void SetMapBox((int Width, int Height) mapSize)
    {
        if (GameForm is null)
        {
            return;
        }

        var (width, height) = GetScaledValues(mapSize.Width, mapSize.Height);

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

        var cellPictureBox = CreateCellPictureBox(cell, GameForm.MapBox);

        if (cell is Player)
        {
            AnimationEngine.IsPlayerFacingRight = true;
            AnimationEngine.PlayerPictureBox = cellPictureBox;
        }

        GameForm.MapBox.Controls.Add(cellPictureBox);
    }

    public static Image? GetCellImage(CellBase? cell)
    {
        return cell switch
        {
            Player => Resources.Player_Right,
            Prize => Resources.Prize,
            Stop => Resources.Stop,
            Trap => Resources.Trap,
            Wall => Resources.Wall,
            _ => null
        };
    }

    public static PictureBox CreateCellPictureBox(CellBase cell, Control? parent)
    {
        var (width, height) = GetScaledValues();
        var (cellX, cellY) = GetScaledValues(cell.X, cell.Y);

        var cellPictureBox = new PictureBox
        {
            Image = GetCellImage(cell),
            Enabled = false,
            Location = new Point(cellX, cellY),
            BackColor = Color.Transparent,
            Size = new Size(width, height),
            SizeMode = PictureBoxSizeMode.Zoom
        };

        if (parent != null)
        {
            cellPictureBox.Parent = parent;
        }

        return cellPictureBox;
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

        var controlsText = GameForm.ControlsTipLabel.Text;

        // Replace numbers in controls tip template with corresponding keys
        for (var i = 0; controlsText.Contains(i.ToString()); i++)
        {
            controlsText = controlsText.Replace(i.ToString(), controlsKeys[i].ToString());
        }

        controlsTip.Text = controlsText;
        GameForm.ControlsTipLabel.Text = controlsTip.Text;

        var x = GetCenteredValue(GameForm.LeftSection.Size.Width, GameForm.ControlsTipLabel.Width);
        var y = GetCenteredValue(GameForm.LeftSection.Size.Height, GameForm.ControlsTipLabel.Height);

        GameForm.ControlsTipLabel.Location = new Point(x, y);
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || GameForm is null)
        {
            return;
        }

        score.Text = "Score:";
        GameForm.ScoreLabel.Text = score.Text;
        GameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();

        var x = GetCenteredValue(GameForm.RightSection.Size.Width, GameForm.ScoreBox.Width);
        var y = GetCenteredValue(GameForm.RightSection.Size.Height, GameForm.ScoreBox.Height);

        GameForm.ScoreBox.Location = new Point(x, y);
    }

    public static int GetCenteredValue(int parentValue, int childValue)
    {
        return (parentValue - childValue) / 2;
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
}