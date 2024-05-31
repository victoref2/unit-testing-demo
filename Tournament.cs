using System;
using System.Collections.Generic;

namespace Testing_Demo
{
    public class Tournament
    {
        public List<Team> Teams { get; private set; }
        private readonly Logger? _logger;

        public Tournament(Logger? logger = null)
        {
            Teams = new List<Team>();
            _logger = logger;
            _logger?.Log("Tournament created.");
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
            _logger?.Log($"Team {team.Name} added to the tournament.");
        }

        public void PlayMatch(Team team1, Team team2, Team winner)
        {
            if (!Teams.Contains(team1) || !Teams.Contains(team2))
            {
                _logger?.Log("One or both teams are not part of the tournament. Match not played.");
                return;
            }

            Game match = new Game(team1, team2);
            match.PlayMatch(winner);
            _logger?.Log($"Match played between {team1.Name} and {team2.Name}. Winner: {winner.Name}");
        }

        public Team GetTeamByName(string name)
        {
            Team team = Teams.Find(t => t.Name == name);
            if (team == null)
            {
                _logger?.Log($"Team with name {name} not found.");
            }
            else
            {
                _logger?.Log($"Team {name} found.");
            }
            return team;
        }

        public List<Team> GetStandings()
        {
            Teams.Sort((team1, team2) => team2.Points.CompareTo(team1.Points));
            _logger?.Log("Standings retrieved.");
            return Teams;
        }
    }
}
