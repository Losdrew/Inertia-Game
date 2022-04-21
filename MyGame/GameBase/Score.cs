namespace MyGame
{
    class Score : VisualObject
    {
        public int CurrentScore { get; set; }

        public int TotalScore { get; set; }

        public Score() 
        {
            TotalScore = 0;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(
                Console.WindowWidth - Map.MapWidth,
                Console.WindowHeight - Map.MapHeight - 1
            );

            Console.Write($"Score: ");

            if (TotalScore > 0)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(TotalScore);
        }

        public void Update()
        {
            Console.SetCursorPosition(
                Console.WindowWidth - Map.MapWidth + "Score: ".Length,
                Console.WindowHeight - Map.MapHeight - 1
            );

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(TotalScore + ++CurrentScore);

            Console.ResetColor();
        }

        public void Save()
        {
            TotalScore += CurrentScore;
            CurrentScore = 0;
        }

        public void Reset()
        {
            TotalScore = 0;
            CurrentScore = 0;
        }
    }
}
