using System;
using System.Linq;

namespace simpleBowlingKata
{
    public class Game
    {
        public int[][] Rolls;

        public Frame[] Frames;

        public int Score;

        public Game(int[][] Rolls)
        {
            Score = 0;

            this.Rolls = Rolls;
            // Create an array of rolls
            Frames = new Frame[Rolls.Length];
            for (int i = 0; i < Rolls.Length - 1; i++)
            {
                Frames[i] = new Frame(0, false);
            }

            Frames[Rolls.Length - 1] = new Frame(0, true);
            // Parse values in the Rolls[][] with the corresponding frame and roll
            for (int i = 0; i < Rolls.Length; i++)
            {
                for(int j = 0; j < Frames[i].Rolls.Length; j++)
                {
                    Frames[i].Rolls[j] = Rolls[i][j];
                }
            }
        }


        public int calculateFinalScore()
        {
            int score = calculateBonusFrameScore();

            for (int i = 0; i < Frames.Length - 1; i++)
            {
                int[] currentRollLocation = new int[] { i, 0 };

                int[] nextRollLocation = calculateNextRollIndex(currentRollLocation);

                int[] secondNextRollLocation = calculateNextRollIndex(nextRollLocation);

                // A strike has been scored
                if (Frames[i].Rolls[0] == 10)
                {
                    Frames[i].Score += Frames[i].Rolls[0];
                    Frames[i].Score += Frames[nextRollLocation[0]].Rolls[nextRollLocation[1]];
                    Frames[i].Score += Frames[secondNextRollLocation[0]].Rolls[secondNextRollLocation[1]];
                }
                //A spare has been scored
                else if (Frames[i].Rolls[0] + Frames[i].Rolls[1] == 10)
                {
                    Frames[i].Score += Frames[i].Rolls[0];
                    Frames[i].Score += Frames[i].Rolls[1];  // The total at this point should be 10
                    Frames[i].Score += Frames[secondNextRollLocation[0]].Rolls[secondNextRollLocation[1]];
                }

                //Nothing special has happened
                else
                {
                    Frames[i].Score += Frames[i].Rolls[0];
                    Frames[i].Score += Frames[i].Rolls[1];
                }
            }
            // Total up the score
            for (int i = 0; i < Frames.Length; i++)
            {
                score += Frames[i].Score;
            }
            return score;
        }

        private int calculateBonusFrameScore()
        {
            
            var frameScore = Frames[Frames.Length - 1].Rolls.Sum();

            return frameScore;
        }

        /*
         *  Takes the location of the current roll and calcululates the location of the next one
         */
        private int[] calculateNextRollIndex(int[] rollLocationIndex)
        {
            // If the current frame is the bonus frame
            if (Frames[rollLocationIndex[0]].isBonus)
            {
                // The next roll will be in the same frame
                int[] nextRollLocation = new int[] { rollLocationIndex[0], rollLocationIndex[1] + 1 };
                return nextRollLocation;
            }
            // If the current roll scores a strike
            else if (Frames[rollLocationIndex[0]].Rolls[rollLocationIndex[1]] == 10)
            {
                //  The next roll will be the first roll of the next frame
                int[] nextRollLocation = new int[] { rollLocationIndex[0] + 1, 0 }; 
                return nextRollLocation;
            }
            // If the current roll is the second roll in the frame
            else if (rollLocationIndex[1] == 1)
            {
                // the next roll will be the first roll of the next frame
                int[] nextRollLocation = new int[] { rollLocationIndex[0] + 1, 0 }; 
                return nextRollLocation;
            }
            else
            {   // The next roll will be in the same frame
                int[] nextRollLocation = new int[] { rollLocationIndex[0], rollLocationIndex[1] + 1 }; 
                return nextRollLocation;
            }
        }
    }
}