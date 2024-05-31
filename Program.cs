using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Testing_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConfiguration(configuration.GetSection("Logging"));
                    builder.AddConsole();
                })
                .AddSingleton<IConfiguration>(configuration)
                .BuildServiceProvider();

            
            var logger = serviceProvider.GetService<ILogger<Program>>();
            var tournamentLogger = serviceProvider.GetService<ILogger<Tournament>>();

            logger.LogInformation("Program started");

            Tournament tournament = new Tournament(tournamentLogger);

            
            Team team1 = new Team("Team A");
            Team team2 = new Team("Team B");
            Team team3 = new Team("Team C");

            logger.LogInformation("Teams created");

            tournament.AddTeam(team1);
            tournament.AddTeam(team2);
            tournament.AddTeam(team3);

            logger.LogInformation("Teams added");

            
            tournament.PlayMatch(team1, team2, team1);
            tournament.PlayMatch(team2, team3, team2);
            tournament.PlayMatch(team1, team3, team1);

            logger.LogInformation("Matches completed");

            
            List<Team> standings = tournament.GetStandings();

            Console.WriteLine("Tournament Standings:");
            foreach (var team in standings)
            {
                Console.WriteLine(team);
            }
            logger.LogInformation("Program stopped");
        }
    }
}
