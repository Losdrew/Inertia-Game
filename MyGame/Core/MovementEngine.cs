using MyGame.Entities;
using MyGame.Miscellaneous;

namespace MyGame.Core;

public static class MovementEngine
{
    // Time between frames
    private const int FrameMs = 100;

    private static bool _isMoving;

    public static event AudioEngine.SoundHandler? PlayAudio;

    public static bool Move(Map map)
    {
        while (true)
        {
            var key = InputEngine.GetInput(Enum.GetValues<Direction>().Cast<ConsoleKey>());

            _isMoving = true;

            while (_isMoving)
            {
                var (x, y) = map.GetDestination(map.Player.X, map.Player.Y, (Direction)key);

                PlayAudioOnCell(map[x, y]);

                switch (map[x, y])
                {
                    case Prize or Stop:
                        map[x, y] = new Cell(x, y);
                        _isMoving = false;
                        break;

                    case Wall:
                        _isMoving = false;
                        continue;

                    // Lose condition
                    case Trap:
                        return false;
                }

                // Win condition
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

    private static void PlayAudioOnCell<T>(T cellObject) where T : Cell?
    {
        switch (cellObject)
        {
            case Wall: PlayAudio?.Invoke("Wall"); break;
            case Trap: PlayAudio?.Invoke("Trap"); break;
            case Prize: PlayAudio?.Invoke("Prize"); break;
            case Stop: PlayAudio?.Invoke("Stop"); break;
        }
    }

    private static void PlayAudioOnWin() => PlayAudio?.Invoke("Win");

    private static void ChangePlayerPosition(Player player, int x, int y)
    {
        player.Clear();
        (player.X, player.Y) = (x, y);
        player.Draw();
    }
}