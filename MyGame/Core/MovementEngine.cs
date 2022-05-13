using MyGame.Entities;
using MyGame.Miscellaneous;

namespace MyGame.Core;

public class MovementEngine
{
    // Time between frames
    private const int FrameMs = 100;

    public event AudioEngine.SoundHandler? PlayAudio;

    public bool Move(Map map)
    {
        while (true)
        {
            var key = Console.ReadKey(true).Key;

            // Movement begins when key is defined in controls
            var isMoving = Enum.IsDefined((Direction)key);

            while (isMoving)
            {
                var (x, y) = map.GetDestination(map.Player.X, map.Player.Y, (Direction)key);

                PlayAudioOnCell(map[x, y]);

                switch (map[x, y])
                {
                    case Prize or Stop:
                        map.ClearCell(x, y);
                        isMoving = false;
                        break;

                    case Wall:
                        isMoving = false;
                        continue;

                    case Trap:
                        return false;
                }

                if (map.PrizeCount == 0)
                {
                    PlayAudioOnWin();
                    return true;
                }

                ChangePlayerPosition(map.Player, x, y);

                // Artificial lag for smooth movement
                Thread.Sleep(FrameMs);
            }
        }
    }

    private void PlayAudioOnCell<T>(T cellObject) where T : Cell
    {
        switch (cellObject)
        {
            case Wall: PlayAudio?.Invoke("Wall"); break;
            case Trap: PlayAudio?.Invoke("Trap"); break;
            case Prize: PlayAudio?.Invoke("Prize"); break;
            case Stop: PlayAudio?.Invoke("Stop"); break;
        }
    }

    private void PlayAudioOnWin() => PlayAudio?.Invoke("Win");

    private void ChangePlayerPosition(Player player, int x, int y)
    {
        player.Clear();
        (player.X, player.Y) = (x, y);
        player.Draw();
    }
}