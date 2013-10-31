using System;

namespace Minesweeper
{
    public class Score
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }
}