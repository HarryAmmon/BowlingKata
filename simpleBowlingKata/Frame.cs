using System;
using System.Collections.Generic;
using System.Text;

namespace simpleBowlingKata
{
    public class Frame
    {
        // This class exists just to hold the objects state, it should not have any behaviour
        public int Score;
        public int[] Rolls;
        public bool isBonus;

        public Frame(int Score, bool isBonus)
        {
            this.Score = 0;
            this.isBonus = isBonus;
            if (isBonus)
            {
                Rolls = new int[3];
            }
            else
            {
                Rolls = new int[2];
            }
        }
    }
}
