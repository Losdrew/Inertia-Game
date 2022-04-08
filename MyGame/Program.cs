namespace MyGame
{
    class Program
    {
        public const int MapWidth = 20;
        public const int MapHeight = 10;
        public const ConsoleColor BorderColor = ConsoleColor.Red;

        static void Main()
        {
            Console.SetWindowSize(MapWidth, MapHeight);
            Console.SetBufferSize(MapWidth, MapHeight);
            Console.CursorVisible = false;
            
            DrawBorder();
            Console.ReadKey();
        }

        static void DrawBorder()
        {
            for (int i = 0; i < MapWidth; i++)
            {
                new Cell(i, 0, "Wall", BorderColor).Draw();
                new Cell(i, MapHeight - 1, "Wall", BorderColor).Draw();
            }

            for (int i = 0; i < MapHeight; i++)
            {
                new Cell(0, i, "Wall", BorderColor).Draw();
                new Cell(MapWidth - 1, i, "Wall", BorderColor).Draw();
            }
        }
    }
}