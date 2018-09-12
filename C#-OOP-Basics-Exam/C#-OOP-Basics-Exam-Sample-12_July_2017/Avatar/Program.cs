using System;
using System.Collections.Generic;
using System.Linq;

namespace Avatar
{
    class Program
    {
        static void Main(string[] args)
        {
            var nationsBuilder = new NationsBuilder();
            string line;
            while ((line = Console.ReadLine()) != "Quit")
            {
                var tokens = line.Split().ToList();
                var command = tokens[0];
                tokens = tokens.Skip(1).ToList();
                InvokeCommand(nationsBuilder, tokens, command);
            }
            Console.WriteLine(nationsBuilder.GetWarsRecord());
        }

        private static void InvokeCommand(NationsBuilder nationsBuilder, List<string> tokens, string command)
        {
            switch (command)
            {
                case "Bender":
                    nationsBuilder.AssignBender(tokens);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(tokens);
                    break;
                case "Status":
                    Console.WriteLine(nationsBuilder.GetStatus(tokens[0]));
                    break;
                case "War":
                    nationsBuilder.IssueWar(tokens[0]);
                    break;
            }
        }
    }
}