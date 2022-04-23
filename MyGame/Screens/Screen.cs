#pragma warning disable CA1416

namespace MyGame
{
    abstract class Screen : VisualObject
    {
        public string Path { get; set; }

        public (int x, int y) WindowSize { get; set; }

        public (int x, int y) CursorPosition { get; set; }

        public Dictionary<ConsoleKey, GameState> Choice { get; set; }

        public override void Draw()
        {
            Console.Clear();
            Console.SetWindowSize(WindowSize.x, WindowSize.y);
            Console.SetBufferSize(WindowSize.x, WindowSize.y);

            Console.ForegroundColor = Color;

            Console.WriteLine();

            foreach (var line in File.ReadLines(Path, System.Text.Encoding.UTF8))
            {
                if (line.Contains("Choose"))
                    Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(line);
            }

        }

        public GameState GetInput()
        {
            Draw();

            Console.CursorVisible = true;
            Console.SetCursorPosition(CursorPosition.x, CursorPosition.y);

            ConsoleKey key;

            while (true)
            {
                key = Console.ReadKey(true).Key;

                if (Choice.ContainsKey(key))
                    return Choice[key];
            }
        }
    }
}
