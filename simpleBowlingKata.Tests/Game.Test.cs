using System;
using Xunit;

namespace simpleBowlingKata.Tests
{
    public class GameTests
    {
        

        [Fact]
        public void NewGameHasZeroScore()
        {
            int[][] rolls = new int[][]
             {
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0},
                new int[]{0, 0, 0},
             };

            Game game = new Game(rolls);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void GameOfStrikesGivesMaximunScore()
        {
            // arrange
            int[][] rolls = new int[][]
            {
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 0},
                new int[]{10, 10, 10}
            };

            var expected = 300;

            var game = new Game(rolls);

            // act
            var actual = game.calculateFinalScore();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GameOfSparesAndOneStrikeGivesCorrectScore() // expected score calculated using  "http://www.sportcalculators.com/bowling-score-calculator"
        {
            // arrange
            int[][] rolls = new int[][]
            {
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1},
                new int[]{9, 1, 10},
            };
            var game = new Game(rolls);
            var expected = 191;
            
            // act
            var actual = game.calculateFinalScore();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AssortmentOfScoresGivesCorrectScore() // expected score calculated using  "http://www.sportcalculators.com/bowling-score-calculator"
        {
            // arrange
            int[][] rolls = new int[][]
            {
                new int[]{4,4},
                new int[]{7,1},
                new int[]{5,5},
                new int[]{10,0},
                new int[]{10,0},
                new int[]{6,2},
                new int[]{5,3},
                new int[]{9,1},
                new int[]{7,2},
                new int[]{10,0,2},
            };

            var game = new Game(rolls);

            var expected = 134;

            // act
            var actual = game.calculateFinalScore();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
