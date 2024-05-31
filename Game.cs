using System;

namespace Testing_Demo;

public class Game
{
    public Team Team1 { get; private set; }
    public Team Team2 { get; private set; }
    public Team? Winner { get; private set; }
    public Team? Loser { get; private set; }
    public bool IsTie { get; private set; }

    public Game(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;
        IsTie = false;
    }

    private static readonly Random random = new Random();

    public void PlayMatch(Team winner = null)
    {
        if (winner == null)
        {
            // Randomly select a winner if none is provided
            int randomNumber = random.Next(2); // Generates 0 or 1
            winner = (randomNumber == 0) ? Team1 : Team2;
        }

        if (winner != Team1 && winner != Team2)
        {
            throw new ArgumentException("Winner must be one of the teams playing the match");
        }

        Winner = winner;
        Loser = (winner == Team1) ? Team2 : Team1;

        Winner.RecordWin();
        Loser.RecordLoss();
        IsTie = false;
    }
}

