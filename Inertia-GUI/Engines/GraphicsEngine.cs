using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GUI.Engines;

public static class GraphicsEngine
{
    private const int CellWidthScale = 40;
    private const int CellHeightScale = 45;

    public static GameForm? GameForm { private get; set; }

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
            Player => Resources.Player,
            Prize => Resources.Prize,
            Stop => Resources.Stop,
            Trap => Resources.Trap,
            Wall => Resources.Wall,
            _ => Resources.Error
        };

        image = ResizeImage(image, CellWidthScale, CellHeightScale);

        var cellPictureBox = new PictureBox
        {
            Image = image,
            Region = CreateRegion(image),
            Parent = GameForm.MapBox,
            Size = new Size(CellWidthScale, CellHeightScale),
            Location = new Point(cell.X * CellWidthScale, cell.Y * CellHeightScale)
        };

        GameForm.MapBox.Controls.Add(cellPictureBox);
    }

    public static void ClearCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell || GameForm is null)
        {
            return;
        }

        var cellPictureBoxLocation = new Point(cell.X * CellWidthScale, cell.Y * CellHeightScale);

        foreach (Control control in GameForm.MapBox.Controls)
        {
            if (control.Location == cellPictureBoxLocation)
            {
                GameForm.MapBox.Controls.Remove(control);
            }
        }
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
        GameForm.ScoreNumberLabel.ForeColor = score.Color;
    }

    private static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        var graphics = Graphics.FromImage(destImage);

        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        var wrapMode = new ImageAttributes();
        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        return destImage;
    }

    private static Region CreateRegion(Bitmap maskImage)
    {
        var mask = maskImage.GetPixel(0, 0);
        var graphicsPath = new GraphicsPath();

        for (var x = 0; x < maskImage.Width; x++)
        {
            for (var y = 0; y < maskImage.Height; y++)
            {
                if (!maskImage.GetPixel(x, y).Equals(mask))
                {
                    graphicsPath.AddRectangle(new Rectangle(x, y, 1, 1));
                }
            }
        }

        return new Region(graphicsPath);
    }
}