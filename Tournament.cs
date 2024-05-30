using System;
using System.Collections.Generic;

namespace Testing_Demo
{
    public class Tournament
    {
        public List<Team> Teams { get; private set; }

        public Tournament()
        {
            Teams = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public void PlayMatch(Team team1, Team team2, Team winner)
        {
            Game match = new Game(team1, team2);
            match.PlayMatch(winner);
        }

        public Team GetTeamByName(string name)
        {
            return Teams.Find(team => team.Name == name);
        }

        public List<Team> GetStandings()
        {
            Teams.Sort((team1, team2) => team2.Points.CompareTo(team1.Points));
            return Teams;
        }
    }
}
