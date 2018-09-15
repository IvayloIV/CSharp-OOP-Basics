using System;
using System.Collections.Generic;

namespace _05.Kings_Gambit_Extended
{
    class Program
    {
        static void Main(string[] args)
        {
            var king = CreateKing();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var command = tokens[0];
                switch (command)
                {
                    case "Attack":
                        king.Defence();
                        break;
                    case "Kill":
                        king.PoisonDefender(tokens[1]);
                        break;
                }
            }
        }

        private static IAttackable CreateKing()
        {
            var defenders = new List<IDefender>();
            var kingName = Console.ReadLine();
            var king = new King(kingName, defenders);

            var royalGuards = Console.ReadLine().Split();
            foreach (var royalGuard in royalGuards)
            {
                king.AddDefender(new RoyalGuard(royalGuard));
            }

            var footmens = Console.ReadLine().Split();
            foreach (var footmen in footmens)
            {
                king.AddDefender(new Footman(footmen));
            }

            return king;
        }
    }
}
