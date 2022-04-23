namespace MyGame
{
    class Cell : VisualObject
    {
        public char CellType { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            CellType = ' ';
        }

        public override void Draw()
        {
            Console.SetCursorPosition(
                Map.MapLeftMargin + X,
                (Console.WindowHeight - Map.MapHeight) / 2 + Y);

            Console.ForegroundColor = Color;

            Console.Write(CellType);

            Console.ResetColor();
        }
    }
}