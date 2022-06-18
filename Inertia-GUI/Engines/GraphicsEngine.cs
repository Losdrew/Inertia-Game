using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using CommonCodebase.Core;
using CommonCodebase.Entities;
using CommonCodebase.Miscellaneous;
using GUI.Forms;

namespace GUI.Engines;

public static class GraphicsEngine
{
    private const int CellWidthScale = 40;
    private const int CellHeightScale = 45;

    public static MainForm? MainForm { private get; set; }

    public static void SetMapBoxSize()
    {
        if (MainForm is null)
            return;

        MainForm.MapBox.Size = new Size(
            Map.Width * CellWidthScale,
            Map.Height * CellHeightScale);
    }

    public static void DrawCell(object? sender, EventArgs e)
    {
        if (sender is not CellBase cell || cell is Empty || MainForm is null)
            return;

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
            Parent = MainForm.MapBox,
            Size = new Size(CellWidthScale, CellHeightScale),
            Location = new Point(cell.X * CellWidthScale, cell.Y * CellHeightScale)
        };

        cellPictureBox.BringToFront();
    }

    public static void DrawControls(object? sender, EventArgs e)
    {
        if (sender is not ControlsTip controlsTip || MainForm is null)
            return;

        MainForm.ControlsTipLabel.Text = controlsTip.Text;

        MainForm.ControlsTipLabel.Top = (MainForm.MapBox.Height - MainForm.ControlsTipLabel.Height) / 2;
        MainForm.ControlsTipLabel.Left = (MainForm.LeftSection.Width - MainForm.ControlsTipLabel.Width) / 2;
    }

    public static void DrawScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || MainForm is null)
            return;

        MainForm.ScoreLabel.Text = score.Text;

        MainForm.ScoreBox.Top = (MainForm.MapBox.Height - MainForm.ScoreBox.Height) / 2;
        MainForm.ScoreBox.Left = (MainForm.RightSection.Width - MainForm.ScoreBox.Width) / 2;
    }

    public static void UpdateScore(object? sender, EventArgs e)
    {
        if (sender is not Score score || MainForm is null)
            return;

        MainForm.ScoreNumberLabel.Text = score.ScoreToDraw.ToString();
        MainForm.ScoreNumberLabel.ForeColor = score.Color;
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
        graphics.DrawImage(
            image, destRect, 0, 0,
            image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        return destImage;
    }

    private static Region CreateRegion(Bitmap maskImage)
    {
        var mask = maskImage.GetPixel(0, 0);
        var graphicsPath = new GraphicsPath();

        for (var x = 0; x < maskImage.Width; x++)
        for (var y = 0; y < maskImage.Height; y++)
            if (!maskImage.GetPixel(x, y).Equals(mask))
                graphicsPath.AddRectangle(new Rectangle(x, y, 1, 1));

        return new Region(graphicsPath);
    }
}