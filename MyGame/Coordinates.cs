namespace MyGame
{
    public struct Coordinates
    {
        public int X { get; set; }
        
        public int Y { get; set; }

        public Coordinates(int x, int y)
        { 
            X = x;
            Y = y;
        }

        public Coordinates(Random random, int limitX, int limitY)
        {
            X = random.Next(limitX);
            Y = random.Next(limitY);
        }
    }
}
