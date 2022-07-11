using CommonCodebase.Entities;
using System.Runtime.Serialization;

namespace CommonCodebase.Core;

[DataContract]
public class Map : VisualObject
{
    public const int MaxPlayerCount = 1;

    public int PlayerCount;

    private Player? _player;

    private int _prizeCount;

    public Map()
    {
        Matrix = new CellBase[Size.Width, Size.Height];
    }

    public Map(int width, int height)
    {
        Size = (width, height);
        Matrix = new CellBase[Size.Width, Size.Height];
    }

    public Map(Map map) : this(map.Size.Width, map.Size.Height)
    {
        for (var y = 0; y < Size.Height; y++)
        {
            for (var x = 0; x < Size.Width; x++)
            {
                this[x, y] = map[x, y];
            }
        }
    }

    [DataMember] 
    public string? Name { get; set; }

    [DataMember] 
    public (int Width, int Height) Size { get; private set; }

    [DataMember]
    public Player? Player
    {
        get => _player;
        private set
        {
            if (value != null)
            {
                if (PlayerCount >= MaxPlayerCount)
                {
                    throw new ArgumentOutOfRangeException($"Player count can't exceed {MaxPlayerCount}.");
                }

                PlayerCount++;
            }

            _player = value;
        }
    }

    [DataMember]
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

    [DataMember] 
    private CellBase?[,] Matrix { get; set; }

    public CellBase? this[int x, int y]
    {
        get => Matrix[x, y];
        set
        {
            // Player assignment
            if (value is Player)
            {
                Player = new Player(value.X, value.Y);
            }

            // Player deletion
            if (Matrix[x, y] is Player && value is not Player _)
            {
                Player = null;
            }

            // Prize assignment
            if (value is Prize)
            {
                PrizeCount++;
            }

            // Prize deletion
            if (Matrix[x, y] is Prize)
            {
                PrizeCount--;
            }

            Matrix[x, y] = value;
        }
    }

    public event Action? UpdateScore;

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

    public Map CreateMap()
    {
        var random = new Random();
        CreateCompletablePath(random);
        FillMap(random);
        return this;
    }

    public override void Draw()
    {
        // Draw map
        for (var y = 0; y < Size.Height; y++)
        {
            for (var x = 0; x < Size.Width; x++)
            {
                this[x, y]?.Draw();
            }
        }

        // Draw player
        Player?.Draw();
    }

    public bool IsOnBorders(int x, int y)
    {
        return x == 0 || x == Size.Width - 1 || y == 0 || y == Size.Height - 1;
    }

    private static Direction GetRandomDirection(Random random)
    {
        var directions = Enum.GetValues<Direction>();
        return directions[random.Next(directions.Length)];
    }

    private void CreateCompletablePath(Random random)
    {
        var pathLength = random.Next(GetAreaOfMap() / 2, GetAreaOfMap());
        var start = (random.Next(1, Size.Width - 1), random.Next(1, Size.Height - 1));

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

            if (!IsOnBorders(newX, newY) && (IsUndefined(newX, newY) || IsEmpty(newX, newY)))
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

    private int GetAreaOfMap()
    {
        return (Size.Width - 2) * (Size.Height - 2);
    }

    private bool IsEmpty(int x, int y)
    {
        return this[x, y] is Empty;
    }

    private bool IsUndefined(int x, int y)
    {
        return this[x, y] is null;
    }

    private void CreateWallAhead(int x, int y, Direction direction)
    {
        this[x, y] = new Empty(x, y);

        var (newX, newY) = GetDestination(x, y, direction);

        if (!IsOnBorders(newX, newY) && IsUndefined(newX, newY))
        {
            this[newX, newY] = new Wall(newX, newY);
        }
    }

    private void FillMap(Random random)
    {
        for (var y = 0; y < Size.Height; y++)
        {
            for (var x = 0; x < Size.Width; x++)
            {
                // Create wall at map border
                if (IsOnBorders(x, y))
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

                // To make gaps between cells (if previous cell is not empty)
                if (!IsOnBorders(x + 1, y) && IsUndefined(x + 1, y) && !IsEmpty(x, y))
                {
                    this[++x, y] = new Empty(x, y);
                }
            }
        }
    }
}