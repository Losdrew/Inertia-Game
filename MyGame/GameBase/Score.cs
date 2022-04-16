namespace MyGame
{
    class Score
    {
        private int PreviousScore { get; set; }
        public int CurrentScore { get; set; }

        public void Draw()
        {
            Console.SetCursorPosition(
            Console.WindowWidth - Program.MapWidth,
            Console.WindowHeight - Program.MapHeight - 1);

            Console.Write($"Score: ");

            if (PreviousScore > 0)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(PreviousScore);
        }

        public void Update()
        {
            CurrentScore++;

            Console.SetCursorPosition(
            Console.WindowWidth - Program.MapWidth + "Score: ".Length,
            Console.WindowHeight - Program.MapHeight - 1);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(PreviousScore + CurrentScore);
        }

        public void Save()
        {
            PreviousScore += CurrentScore;
            CurrentScore = 0;
        }

        public void Reset()
        {
            PreviousScore = 0;
            CurrentScore = 0;
        }
    }
}
