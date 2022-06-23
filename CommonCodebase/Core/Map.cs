using CommonCodebase.Entities;

namespace CommonCodebase.Core;

public class Map : VisualObject
{
    public const int Width = 20;
    public const int Height = 10;

    private const int MaxPlayerCount = 1;

    private Player? _player;

    private int _playerCount;

    private int _prizeCount;

    public Map()
    {
        Matrix = new CellBase[Width, Height];
    }

    public Map(Map map) : this()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                this[x, y] = map[x, y];
            }
        }
    }

    public Player Player
    {
        get => _player ?? throw new NullReferenceException("Player not placed.");
        private set
        {
            if (_playerCount >= MaxPlayerCount)
            {
                throw new Exception($"Player count can't exceed {MaxPlayerCount}.");
            }

            _player = value;
            _playerCount++;
        }
    }

    public int PrizeCount
    {
        get => _prizeCount;
        private set
        {
            // When prize count decreases, score increases
            if (value < _prizeCount)
            {
                UpdateScore?.Invoke();
            }

            _prizeCount = value;
        }
    }

    private CellBase[,] Matrix { get; }

    public CellBase this[int x, int y]
    {
        get => Matrix[x, y];
        set
        {
            if (value is Player)
            {
                Player = new Player(value.X, value.Y);
            }

            if (value is Prize)
            {
                PrizeCount++;
            }

            if (Matrix[x, y] is Prize)
            {
                PrizeCount--;
            }

            Matrix[x, y] = value;
        }
    }

    public event Action? UpdateScore;

    public void CreateMap()
    {
        var random = new Random();

        CreateCompletablePath(random);

        FillMap(random);
    }

    public static (int x, int y) GetDestination(int x, int y, Direction direction)
    {
        return direction switch
        {
            Direction.Up => (x, y - 1),
            Direction.Down => (x, y + 1),
            Direction.Left => (x - 1, y),
            Direction.Right => (x + 1, y),
            Direction.LeftUp => (x - 1, y - 1),
            Direction.RightUp => (x + 1, y - 1),
            Direction.LeftDown => (x - 1, y + 1),
            Direction.RightDown => (x + 1, y + 1),
            _ => (x, y)
        };
    }

    public override void Draw()
    {
        // Draw map
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                this[x, y].Draw();
            }
        }

        // Draw player
        Player.Draw();
    }

    private void CreateCompletablePath(Random random)
    {
        var pathLength = random.Next(GetAreaOfMap() / 2, GetAreaOfMap());
        var start = (random.Next(1, Width - 1), random.Next(1, Height - 1));

        // (x, y) is current position
        var (x, y) = start;

        // Place player at the start of path 
        this[x, y] = new Player(x, y);
        pathLength--;

        var tries = 0;

        var currentDirection = GetRandomDirection(random);

        while (pathLength > 0)
        {
            // Stop path-making if blocked from all sides
            if (tries == Enum.GetNames<Direction>().Length)
            {
                break;
            }

            var (newX, newY) = GetDestination(x, y, currentDirection);

            if (IsInRangeOfMap(newX, newY) && (IsUndefined(newX, newY) || IsEmpty(newX, newY)))
            {
                tries = 0;

                (x, y) = (newX, newY);

                pathLength--;

                switch (random.Next(100))
                {
                    case < 10:
                        CreateWallAhead(x, y, currentDirection);
                        break;
                    case < 20:
                        this[x, y] = new Prize(x, y);
                        break;
                    case < 30:
                        this[x, y] = new Stop(x, y);
                        break;
                    default:
                        this[x, y] = new Empty(x, y);
                        continue;
                }
            }

            else
            {
                tries++;
            }

            currentDirection = GetRandomDirection(random);
        }

        // If no prize was created, place one at path end
        if (PrizeCount == 0)
        {
            this[x, y] = new Prize(x, y);
        }
    }

    private static int GetAreaOfMap()
    {
        return (Width - 2) * (Height - 2);
    }

    private static Direction GetRandomDirection(Random random)
    {
        var directions = Enum.GetValues<Direction>();

        return directions[random.Next(directions.Length)];
    }

    private static bool IsInRangeOfMap(int x, int y)
    {
        return x is > 0 and < Width - 1 && y is > 0 and < Height - 1;
    }

    private bool IsEmpty(int x, int y)
    {
        return this[x, y] is Empty;
    }

    private bool IsUndefined(int x, int y)
    {
        return this?[x, y] == null;
    }

    private void CreateWallAhead(int x, int y, Direction direction)
    {
        this[x, y] = new Empty(x, y);

        var (newX, newY) = GetDestination(x, y, direction);

        if (IsInRangeOfMap(newX, newY) && IsUndefined(newX, newY))
        {
            this[newX, newY] = new Wall(newX, newY);
        }
    }

    private void FillMap(Random random)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                // Create wall at map border
                if (!IsInRangeOfMap(x, y))
                {
                    this[x, y] = new Wall(x, y);
                }

                // Skip if cell is part of predefined path or wall has been placed
                if (!IsUndefined(x, y))
                {
                    continue;
                }

                // Place cell
                this[x, y] = random.Next(100) switch
                {
                    < 10 => new Wall(x, y),
                    < 30 => new Trap(x, y),
                    < 35 => new Stop(x, y),
                    _ => new Empty(x, y)
                };

                //// To make gaps between cells (if previous cell is not empty)
                if (IsInRangeOfMap(x + 1, y) && IsUndefined(x + 1, y) && !IsEmpty(x, y))
                {
                    this[++x, y] = new Empty(x, y);
                }
            }
        }
    }
}