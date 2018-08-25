using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Football_Team_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var teams = new List<Team>();
                ReadCommands(teams);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void ReadCommands(List<Team> teams)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = command.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    switch (tokens[0])
                    {
                        case "Team":
                            CreateNewTeam(teams, tokens);
                            break;
                        case "Add":
                            AddNewPlayer(teams, tokens);
                            break;
                        case "Remove":
                            RemovePlayer(teams, tokens);
                            break;
                        case "Rating":
                            ShowRatingForTeam(teams, tokens[1]);
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        private static void ShowRatingForTeam(List<Team> teams, string teamName)
        {
            var currentTeam = FindCurrentTeam(teams, teamName);
            IsTeamExist(teamName, currentTeam);
            var stats = currentTeam.GetStats();
            Console.WriteLine($"{teamName} - {stats}");
        }

        private static void RemovePlayer(List<Team> teams, string[] tokens)
        {
            var teamName = tokens[1];
            var playerName = tokens[2];
            var currentTeam = FindCurrentTeam(teams, teamName);
            IsTeamExist(teamName, currentTeam);
            currentTeam.RemovePlayer(playerName);
        }

        private static void CreateNewTeam(List<Team> teams, string[] tokens)
        {
            var teamName = tokens[1];
            var newTeam = new Team(teamName);
            teams.Add(newTeam);
        }

        private static void AddNewPlayer(List<Team> teams, string[] tokens)
        {
            var teamName = tokens[1];
            var searchTeam = FindCurrentTeam(teams, teamName);
            IsTeamExist(teamName, searchTeam);
            var playerName = tokens[2];
            var newPlayer = new Player(playerName, int.Parse(tokens[3]), int.Parse(tokens[4]),
                int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
            searchTeam.AddPlayer(newPlayer);
        }

        private static Team FindCurrentTeam(List<Team> teams, string teamName)
        {
            return teams.FirstOrDefault(a => a.Name == teamName);
        }

        private static void IsTeamExist(string teamName, Team searchTeam)
        {
            if (searchTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}