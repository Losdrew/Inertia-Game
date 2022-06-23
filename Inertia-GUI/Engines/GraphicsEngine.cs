using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Forms;
using GUI.Properties;

namespace GUI.Engines;

public static class GraphicsEngine
{
    private const int CellWidthScale = 45;
    private const int CellHeightScale = 45;

    private static GameForm? GameForm { get; set; }

    private static PictureBox? PlayerPictureBox { get; set; }

    private static (int x, int y) NewPlayerPosition { get; set; }

    public static void GetGameForm(GameForm gameForm)
    {
        GameForm = gameForm;
    }

    public static void SetMapBox()
    {
        if (GameForm is null)
        {
            return;
        }

        // Clearing all controls to draw on an empty MapBox
        GameForm.MapBox.Controls.Clear();

        GameForm.MapBox.Size = new Size(Map.Width * CellWidthScale, Map.Height * CellHeightScale);
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
            Player => Resources.PlayerAnimated,
            Prize => Resources.Prize,
            Stop => Resources.Stop,
            Trap => Resources.Trap,
            Wall => Resources.Wall,
            _ => Resources.Error
        };

        var cellPictureBox = new PictureBox
        {
            Image = image,
            Enabled = false,
            Parent = GameForm.MapBox,
            BackColor = Color.Transparent,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(CellWidthScale, CellHeightScale),
            Location = new Point(cell.X * CellWidthScale, cell.Y * CellHeightScale),
        };

        if (cell is Player)
        {
            PlayerPictureBox = cellPictureBox;
        }

        GameForm.MapBox.Controls.Add(cellPictureBox);
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell || GameForm is null)
        {
            return;
        }

        var cellPictureBox = FindPictureBoxOnMap(new Point(cell.X * CellWidthScale, cell.Y * CellHeightScale));

        if (cellPictureBox != PlayerPictureBox)
        {
            ClearPictureBoxFromMap(cellPictureBox);
        }
    }

    private static PictureBox? FindPictureBoxOnMap(Point pictureBoxLocation)
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
    private static void ClearPictureBoxFromMap(PictureBox? pictureBox)
    {
        if (pictureBox is null || GameForm is null)
        {
            return;
        }

        GameForm.MapBox.Controls.Remove(pictureBox);
    }

    public static void DrawControlsTip(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip || GameForm is null)
        {
            return;
        }

        GameForm.ControlsTipLabel.Text = controlsTip.Text;

        // Horizontal and vertical centering relative to parent panel
        GameForm.ControlsTipLabel.Top = (GameForm.LeftSection.Height - GameForm.ControlsTipLabel.Height) / 2;
        GameForm.ControlsTipLabel.Left = (GameForm.LeftSection.Width - GameForm.ControlsTipLabel.Width) / 2;
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || GameForm is null)
        {
            return;
        }

        GameForm.ScoreLabel.Text = score.Text;
        GameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();

        // Horizontal and vertical centering relative to parent panel
        GameForm.ScoreBox.Top = (GameForm.RightSection.Height - GameForm.ScoreBox.Height) / 2;
        GameForm.ScoreBox.Left = (GameForm.RightSection.Width - GameForm.ScoreBox.Width) / 2;
    }

    public static void UpdateScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || GameForm is null)
        {
            return;
        }

        GameForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();
    }

    public static void StartAnimationTimer(object? sender, EventArgs e)
    {
        if (sender is not Player player || PlayerPictureBox is null || GameForm is null)
        {
            return;
        }

        NewPlayerPosition = (player.X * CellWidthScale, player.Y * CellHeightScale);

        PlayerPictureBox.Enabled = true;

        GameForm.AnimationTimer.Start();
    }

    public static void DoPlayerAnimation(object? sender, EventArgs e)
    {
        if (PlayerPictureBox is null || GameForm is null)
        {
            return;
        }

        var playerLocation = new Point(NewPlayerPosition.x, NewPlayerPosition.y);

        if (PlayerPictureBox.Location != playerLocation)
        {
            if (PlayerPictureBox.Location.X < playerLocation.X)
            {
                PlayerPictureBox.Left += 5;
            }

            if (PlayerPictureBox.Location.X > playerLocation.X)
            {
                PlayerPictureBox.Left -= 5;
            }

            if (PlayerPictureBox.Location.Y < playerLocation.Y)
            {
                PlayerPictureBox.Top += 5;
            }

            if (PlayerPictureBox.Location.Y > playerLocation.Y)
            {
                PlayerPictureBox.Top -= 5;
            }
        }

        else
        {
            StopAnimationTimer();
            return;
        }

        var destinationPictureBox = FindPictureBoxOnMap(playerLocation);

        if (destinationPictureBox == null || destinationPictureBox == PlayerPictureBox)
        {
            return;
        }

        if (destinationPictureBox.Bounds.Contains(PlayerPictureBox.Location))
        {
            ClearPictureBoxFromMap(destinationPictureBox);
        }
    }

    private static void StopAnimationTimer()
    {
        if (PlayerPictureBox is null || GameForm is null)
        {
            return;
        }

        PlayerPictureBox.Enabled = false;

        GameForm.AnimationTimer.Stop();
    }
}