using System;

namespace simpleBowlingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] rolls = new int[][]
             {
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9,1 },
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1, 10},
             };

            Game game = new Game(rolls);
            var finalScore = game.calculateFinalScore();
            Console.WriteLine(finalScore);
        }
    }
}
