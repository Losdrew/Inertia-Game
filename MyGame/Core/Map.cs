using MyGame.Entities;
using MyGame.Miscellaneous;

namespace MyGame.Core;

public class Map : VisualObject
{
    public const int MapWidth = 20;
    public const int MapHeight = 9;

    public Player? Player { get; private set; }

    private Cell[,] Matrix { get; }

    private int _prizeCount;

    public int PrizeCount
    {
        get => _prizeCount;
        private set
        {
            if (value < _prizeCount)
                UpdateScore?.Invoke();

            _prizeCount = value;
        }
    }

    public Map()
    {
        Matrix = new Cell[MapWidth, MapHeight];
    }

    public Map(Map map)
    {
        Matrix = new Cell[MapWidth, MapHeight];

        for (var y = 0; y < MapHeight; y++)
        for (var x = 0; x < MapWidth; x++)
            this[x, y] = map[x, y];

        if (map.Player != null) 
            Player = new Player(map.Player.X, map.Player.Y);

        PrizeCount = map.PrizeCount;
    }

    public event Score.ScoreHandler? UpdateScore;

    public Cell this[int x, int y]
    {
        get { return Matrix[x, y]; }
        set
        {
            if (value is Player)
                Player = value as Player;

            if (value is Prize)
                PrizeCount++;

            if (Matrix[x, y] is Prize)
                PrizeCount--;

            Matrix[x, y] = value;
        }
    }

    public void CreateMap()
    {
        var random = new Random();

        CreateCompletablePath(random);

        FillMap(random);
    }

    public (int x, int y) GetDestination(int x, int y, Direction direction)
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
        Console.SetCursorPosition(0, MapHeight - 9 / 2 - 1);

        List<Direction> directions = new()
        {
            Direction.LeftUp, Direction.Up, Direction.RightUp, Direction.Left,
            Direction.Right, Direction.LeftDown, Direction.Down, Direction.RightDown
        };

        // Get controls template
        var controls = Resources.ControlsTip;

        // Replace numbers in controls string with corresponding keys
        for (var i = 0; controls.Contains(i.ToString()); i++)
            controls = controls.Replace(i.ToString(), ((ConsoleKey)directions[i]).ToString());

        // Draw controls
        Console.WriteLine(controls);

        // Draw map
        for (var y = 0; y < MapHeight; y++)
        for (var x = 0; x < MapWidth; x++)
            this[x, y].Draw();

        // Draw player
        Player?.Draw();
    }

    private void CreateCompletablePath(Random random)
    {
        var pathLength = random.Next(GetAreaOfMap() / 2, GetAreaOfMap());
        var start = (random.Next(1, MapWidth - 1), random.Next(1, MapHeight - 1));

        // (x, y) is current position
        var (x, y) = start;

        // Place player at the start of path 
        this[x, y] = new Player(x, y);
        pathLength--;

        var tries = 0;
        var currentDirection = GetRandomDirection(random);

        while (pathLength > 0)
        {
            var (newX, newY) = GetDestination(x, y, currentDirection);

            // Stop pathmaking if blocked from all sides
            if (tries == 8)
                break;

            if (IsInRangeOfMap(newX, newY) && (IsUndefined(newX, newY) || IsEmpty(newX, newY)))
            {
                tries = 0;

                (x, y) = (newX, newY);

                pathLength--;

                switch (random.Next(100))
                {
                    case < 10: CreateWallAhead(x, y, currentDirection); break;
                    case < 20: this[x, y] = new Prize(x, y); break;
                    case < 30: this[x, y] = new Stop(x, y); break;
                    default: this[x, y] = new Cell(x, y); continue;
                }
            }

            else tries++;

            currentDirection = GetRandomDirection(random);
        }

        // If no prize was created, place one at path end
        if (PrizeCount == 0)
            this[x, y] = new Prize(x, y);
    }

    private int GetAreaOfMap()
    {
        return (MapWidth - 2) * (MapHeight - 2);
    }

    private Direction GetRandomDirection(Random random)
    {
        var directions = Enum.GetValues<Direction>();

        return directions[random.Next(directions.Length)];
    }

    private bool IsInRangeOfMap(int x, int y)
    {
        return x is > 0 and < MapWidth - 1 && y is > 0 and < MapHeight - 1;
    }

    private bool IsEmpty(int x, int y)
    {
        return this[x, y].GetType().IsAssignableFrom(typeof(Cell));
    }

    private bool IsUndefined(int x, int y)
    {
        return this[x, y] == null;
    }

    private void CreateWallAhead(int x, int y, Direction direction)
    {
        this[x, y] = new Cell(x, y);

        var (newX, newY) = GetDestination(x, y, direction);

        if (IsInRangeOfMap(newX, newY) && IsUndefined(newX, newY))
            this[newX, newY] = new Wall(newX, newY);
    }

    private void FillMap(Random random)
    {
        for (var y = 0; y < MapHeight; y++)
        for (var x = 0; x < MapWidth; x++)
        {
            // Create wall at map border
            if (!IsInRangeOfMap(x, y)) 
                this[x, y] = new Wall(x, y);

            // Skip if cell is part of predefined path or wall has been placed
            if (!IsUndefined(x, y)) continue;

            // Place cell
            this[x, y] = random.Next(100) switch
            {   
                < 10 => new Wall(x, y),
                < 30 => new Trap(x, y),
                < 35 => new Stop(x, y),
                _ => new Cell(x, y),
            };

            // To make gaps between cells (if previous cell is not empty)
            if (IsInRangeOfMap(x + 1, y) && IsUndefined(x + 1, y) && !IsEmpty(x, y))
                this[++x, y] = new Cell(x, y);
        }
    }
}