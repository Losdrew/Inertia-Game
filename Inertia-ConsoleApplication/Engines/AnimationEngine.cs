using CommonCodebase.Entities;

namespace ConsoleApplication.Engines;

internal static class AnimationEngine
{
    private const int FrameMs = 85;

    public static void StartAnimation(Player player)
    {
        player.Draw();
        Thread.Sleep(FrameMs);
    }
}