using System;

namespace MyGame
{
    public struct Cell
    {
        public enum CellTypes
        {
            Player = 'I',
            Prize = '@',
            Stop = '.',
            Wall = '#',
            Trap = '%'
        }

        public int X { get; }

        public int Y { get; }

        public CellTypes CellType { get; }

        public ConsoleColor Color { get; }

        public Cell(int x, int y, string type, ConsoleColor color)
        {
            X = x;
            Y = y;
            CellType = (CellTypes)Enum.Parse(typeof(MyGame.Cell.CellTypes), type);
            Color = color;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write((char)CellType);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
