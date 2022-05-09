using MyGame.Entities;
using MyGame.Miscellaneous;

namespace MyGame.Core;

public class Map : VisualObject
{
    public static int MapWidth = 20;
    public static int MapHeight = 9;
    public static int MapLeftMargin = 31;

    public Player Player { get; private set; }

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
        Player = new Player(0, 0);
    }

    public Map(Map map)
    {
        Matrix = new Cell[MapWidth, MapHeight];

        for (var y = 0; y < MapHeight; y++)
        for (var x = 0; x < MapWidth; x++)
            Matrix[x, y] = map[x, y];

        Player = new Player(map.Player.X, map.Player.Y);

        PrizeCount = map.PrizeCount;
    }

    public event Score.ScoreHandler? UpdateScore;

    public Cell this[int x, int y] => Matrix[x, y];

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
            Direction.RightDown => (x + 1, y + 1)
        };
    }

    public void ClearCell(int x, int y)
    {
        if (Matrix[x, y] is Prize)
            PrizeCount--;

        CreateCell(x, y, "Cell");
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
            Matrix[x, y].Draw();

        // Draw player
        Player.Draw();
    }

    private void CreateCompletablePath(Random random)
    {
        var pathLength = random.Next(10, (MapWidth - 2) * (MapHeight - 2) / 2);
        var start = (random.Next(1, MapWidth - 1), random.Next(1, MapHeight - 1));

        // (x, y) is current position
        var (x, y) = start;

        // Place player at the start of path 
        CreateCell(x, y, "Player");
        pathLength--;

        var currentDirection = GetRandomDirection(random);
        var tries = 0;

        while (pathLength > 0)
        {
            var (newX, newY) = GetDestination(x, y, currentDirection);

            if (tries == 8)
                break;

            if (IsInRangeOfMap(newX, newY) && (IsUndefined(newX, newY) || IsEmpty(newX, newY)))
            {
                tries = 0;

                (x, y) = (newX, newY);

                pathLength--;

                switch (random.Next(100))
                {
                    case < 10: CreateCell(x, y, "WallAhead", currentDirection); break;
                    case < 20: CreateCell(x, y, "Prize"); break;
                    case < 30: CreateCell(x, y, "Stop"); break;
                    default: CreateCell(x, y, "Cell"); continue;
                }
            }

            currentDirection = GetRandomDirection(random);
            tries++;
        }

        // If no prize was created, place one at path end
        if (PrizeCount == 0)
            CreateCell(x, y, "Prize");
    }

    private Direction GetRandomDirection(Random random)
    {
        var directions = Enum.GetValues<Direction>();

        return directions[random.Next(directions.Length)];
    }

    private bool IsInRangeOfMap(int x, int y)
    {
        return 0 < x && x < MapWidth - 1 && 0 < y && y < MapHeight - 1;
    }

    private bool IsEmpty(int x, int y)
    {
        return Matrix[x, y].GetType().IsAssignableFrom(typeof(Cell));
    }

    private bool IsUndefined(int x, int y)
    {
        return Matrix[x, y] == null;
    }

    private void CreateCell(int x, int y, string cellType, Direction direction = 0)
    {
        switch (cellType)
        {
            case "Player":
                Matrix[x, y] = new Player(x, y);
                Player = new Player(x, y);
                break;

            case "Prize":
                Matrix[x, y] = new Prize(x, y);
                PrizeCount++;
                break;

            case "Stop":
                Matrix[x, y] = new Stop(x, y);
                break;

            case "Trap":
                Matrix[x, y] = new Trap(x, y);
                break;

            case "WallAt":
                Matrix[x, y] = new Wall(x, y);
                break;

            case "WallAhead":
                Matrix[x, y] = new Cell(x, y);
                var (newX, newY) = GetDestination(x, y, direction);
                if (IsUndefined(newX, newY) && IsInRangeOfMap(newX, newY))
                    Matrix[newX, newY] = new Wall(newX, newY);
                break;

            default:
                Matrix[x, y] = new Cell(x, y);
                break;
        }
    }

    private void FillMap(Random random)
    {
        for (var y = 0; y < MapHeight; y++)
        for (var x = 0; x < MapWidth; x++)
        {
            // To create map borders
            if (!IsInRangeOfMap(x, y))
            {
                CreateCell(x, y, "WallAt");
                continue;
            }

            // If not part of previously defined path
            if (IsUndefined(x, y))
            {
                switch (random.Next(100))
                {
                    case < 10: CreateCell(x, y, "WallAt"); break;
                    case < 30: CreateCell(x, y, "Trap"); break;
                    case < 35: CreateCell(x, y, "Stop"); break;
                    default: CreateCell(x, y, "Cell"); break;
                }

                // To make gaps between cells (if previous cell is not empty)
                if (IsInRangeOfMap(x + 1, y) && IsUndefined(x + 1, y) && !IsEmpty(x, y))
                    CreateCell(++x, y, "Cell");
            }
        }
    }
}