using System;

namespace Testing_Demo
{
    public class Team
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public Team(string name)
        {
            Name = name;
            Wins = 0;
            Losses = 0;
            Ties = 0;
            Points = 0;
        }

        public void RecordWin()
        {
            Wins++;
            Points += 3; // Assuming 3 points for a win
        }

        public void RecordLoss()
        {
            Losses++;
        }

        public void RecordTie()
        {
            Ties++;
            Points += 1; // Assuming 1 point for a tie
        }

        public override string ToString()
        {
            return $"{Name} (Wins: {Wins}, Losses: {Losses}, Ties: {Ties}, Points: {Points})";
        }
    }
}
