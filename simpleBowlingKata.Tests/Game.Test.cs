using System;
using Xunit;

namespace simpleBowlingKata.Tests
{
    public class GameTests
    {
        int[][] rolls = new int[][]
             {
                new int[]{0, 2},
                new int[]{4, 4},
                new int[]{5, 1},
                new int[]{5, 2},
                new int[]{5, 3},
                new int[]{5, 4},
                new int[]{8, 1},
                new int[]{7, 1},
                new int[]{6, 1},
                new int[]{5, 1, 0},
             };

        [Fact]
        public void New_Game_Has_Zero_Score()
        {
            Game game = new Game(rolls);

            Assert.Equal(0, game.Score);
        }
    }
}
