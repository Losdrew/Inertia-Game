using CommonCodebase.Entities;
using GUI.Properties;
using Timer = System.Windows.Forms.Timer;

namespace GUI.Engines;

internal static class AnimationEngine
{
    private const int AnimationOffset = 5;

    public static bool IsPlayerFacingRight;
    public static PictureBox? PlayerPictureBox;

    private static Timer? _animationTimer;

    private static Point _newPlayerLocation;
    private static PictureBox? _destinationPictureBox;

    private static readonly Image PlayerImageLeft = Resources.Player_Left;
    private static readonly Image PlayerImageRight = Resources.Player_Right;

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
        if (PlayerPictureBox is null)
        {
            return;
        }

        PlayerPictureBox.Left += GetOffset(PlayerPictureBox.Location.X, _newPlayerLocation.X);

        PlayerPictureBox.Top += GetOffset(PlayerPictureBox.Location.Y, _newPlayerLocation.Y);

        if (_destinationPictureBox != null && PlayerPictureBox.Bounds.IntersectsWith(_destinationPictureBox.Bounds))
        {
            GraphicsEngine.ClearPictureBoxOnMap(_destinationPictureBox);
        }

        if (PlayerPictureBox.Location == _newPlayerLocation)
        {
            StopAnimationTimer();
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

    private static int GetOffset(int currentLocation, int destinationLocation)
    {
        if (currentLocation < destinationLocation)
        {
            return AnimationOffset;
        }

        if (currentLocation > destinationLocation)
        {
            return -AnimationOffset;
        }

        return 0;
    }

    private static void StartAnimationTimer()
    {
        _animationTimer?.Start();

        if (PlayerPictureBox is null)
        {
            return;
        }

        var isMovingRight = _newPlayerLocation.X > PlayerPictureBox.Location.X;

        if ((IsPlayerFacingRight && !isMovingRight) || (!IsPlayerFacingRight && isMovingRight))
        {
            PlayerPictureBox.Image = IsPlayerFacingRight ? PlayerImageLeft : PlayerImageRight;
            IsPlayerFacingRight = !IsPlayerFacingRight;
        }
    }

    private static void StopAnimationTimer()
    {
        _animationTimer?.Stop();

        MovementEngine.Move();
    }
} 
