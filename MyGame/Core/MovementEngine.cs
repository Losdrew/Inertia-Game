using MyGame.Entities;
using MyGame.Miscellaneous;

namespace MyGame.Core;

public class MovementEngine
{
    // Time between frames
    private const int FrameMs = 120;

    public event AudioEngine.AudioHandler? PlaySound;

    public bool Move(Map map)
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;

            // While key is defined in game's controls
            while (Enum.IsDefined((Direction)key))
            {
                var (x, y) = map.GetDestination(map.Player.X, map.Player.Y, (Direction)key);

                if (map[x, y] is Wall)
                {
                    PlaySound?.Invoke(Resources.Wall);
                    break; // Stop moving
                }

                if (map[x, y] is Trap)
                {
                    PlaySound?.Invoke(Resources.GameOver);
                    return false; // Game over
                }

                map.Player.Clear();

                (map.Player.X, map.Player.Y) = (x, y);

                map.Player.Draw();

                if (map[x, y] is Prize or Stop)
                {
                    if (map[x, y] is Prize)
                        PlaySound?.Invoke(Resources.Pickup);

                    if (map[x, y] is Stop)
                        PlaySound?.Invoke(Resources.Stop);

                    map.ClearCell(x, y);

                    if (map.PrizeCount == 0)
                    {
                        PlaySound?.Invoke(Resources.Win);
                        return true; // Win
                    }

                    break; // Stop moving
                }

                // Artificial lag for smooth movement
                Thread.Sleep(FrameMs);
            }
        }
    }
}