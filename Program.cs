using System;
using System.Collections.Generic;

namespace Testing_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Tournament tournament = new Tournament();

            // Adding some teams
            Team team1 = new Team("Team A");
            Team team2 = new Team("Team B");
            Team team3 = new Team("Team C");

            tournament.AddTeam(team1);
            tournament.AddTeam(team2);
            tournament.AddTeam(team3);

            // Playing some matches
            tournament.PlayMatch(team1, team2, team1);
            tournament.PlayMatch(team2, team3, team2);
            tournament.PlayMatch(team1, team3, team1);

            // Displaying standings
            List<Team> standings = tournament.GetStandings();

            Console.WriteLine("Tournament Standings:");
            foreach (var team in standings)
            {
                Console.WriteLine(team);
            }
        }
    }
}







