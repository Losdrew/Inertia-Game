using CommonCodebase.Entities;
using GUI.Properties;
using Timer = System.Windows.Forms.Timer;

namespace GUI.Engines;

internal static class AnimationEngine
{
    private const int AnimationOffset = 5;

    private static bool _isMirrored;

    private static Timer? _animationTimer;

    private static Point _newPlayerLocation;

    private static PictureBox? _destinationPictureBox;

    private static readonly Image PlayerImage = Resources.PlayerAnimated;
    private static readonly Image PlayerImageMirrored = Resources.PlayerAnimated_Mirrored;

    public static PictureBox? PlayerPictureBox { get; set; }

    public static void GetAnimationTimer(Timer animationTimer)
    {
        _animationTimer = animationTimer;
    }

    public static void StartAnimation(Player player)
    {
        if (PlayerPictureBox is null)
        {
            return;
        }

        var (x, y) = GraphicsEngine.GetScaledValues(player.X, player.Y);

        _newPlayerLocation = new Point(x, y);

        _destinationPictureBox = GraphicsEngine.FindPictureBoxOnMap(_newPlayerLocation);

        StartAnimationTimer();
    }

    public static void PlayAnimation(object? sender, EventArgs e)
    {
        if (PlayerPictureBox is null || _animationTimer is null)
        {
            return;
        }

        if (PlayerPictureBox.Location.X < _newPlayerLocation.X)
        {
            PlayerPictureBox.Left += AnimationOffset;
        }

        if (PlayerPictureBox.Location.X > _newPlayerLocation.X)
        {
            PlayerPictureBox.Left -= AnimationOffset;
        }

        if (PlayerPictureBox.Location.Y < _newPlayerLocation.Y)
        {
            PlayerPictureBox.Top += AnimationOffset;
        }

        if (PlayerPictureBox.Location.Y > _newPlayerLocation.Y)
        {
            PlayerPictureBox.Top -= AnimationOffset;
        }

        if (PlayerPictureBox.Location == _newPlayerLocation)
        {
            StopAnimationTimer();
            return;
        }

        if (_destinationPictureBox != null && PlayerPictureBox.Bounds.IntersectsWith(_destinationPictureBox.Bounds))
        {
            GraphicsEngine.ClearPictureBoxOnMap(_destinationPictureBox);
        }
    }

    public static void SetPlayerGifAnimation(bool value)
    {
        if (PlayerPictureBox is null)
        {
            return;
        }

        PlayerPictureBox.Enabled = value;
    }

    private static void StartAnimationTimer()
    {
        // When moving to left, mirror player's image
        if ((!_isMirrored && _newPlayerLocation.X < PlayerPictureBox?.Location.X) ||
            (_isMirrored && _newPlayerLocation.X > PlayerPictureBox?.Location.X))
        {
            PlayerPictureBox.Image = _isMirrored ? PlayerImage : PlayerImageMirrored;
            _isMirrored = !_isMirrored;
        }

        _animationTimer?.Start();
    }

    private static void StopAnimationTimer()
    {
        _animationTimer?.Stop();

        MovementEngine.StartMovement?.Invoke();
    }
} 
