using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Testing_Demo
{
    public class Tournament
    {
        public List<Team> Teams { get; private set; }
        private readonly ILogger<Tournament>? _logger;

        public Tournament(ILogger<Tournament>? logger = null)
        {
            Teams = new List<Team>();
            _logger = logger;
            _logger?.LogInformation("Tournament created.");
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
            _logger?.LogInformation("Team {TeamName} added to the tournament.", team.Name);
        }

        public void PlayMatch(Team team1, Team team2, Team winner)
        {
            if (!Teams.Contains(team1) || !Teams.Contains(team2))
            {
                _logger?.LogWarning("One or both teams are not part of the tournament. Match not played.");
                return;
            }

            Game match = new Game(team1, team2);
            match.PlayMatch(winner);
            _logger?.LogInformation("Match played between {Team1} and {Team2}. Winner: {Winner}", team1.Name, team2.Name, winner.Name);
        }

        public Team GetTeamByName(string name)
        {
            Team team = Teams.Find(t => t.Name == name);
            if (team == null)
            {
                _logger?.LogWarning("Team with name {TeamName} not found.", name);
            }
            else
            {
                _logger?.LogInformation("Team {TeamName} found.", name);
            }
            return team;
        }

        public List<Team> GetStandings()
        {
            Teams.Sort((team1, team2) => team2.Points.CompareTo(team1.Points));
            _logger?.LogInformation("Standings retrieved.");
            return Teams;
        }
    }
}
