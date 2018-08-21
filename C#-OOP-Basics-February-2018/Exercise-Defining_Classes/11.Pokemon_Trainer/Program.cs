using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                if (trainers.All(a => a.Name != trainerName))
                {
                    trainers.Add(new Trainer(trainerName, new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3]))));
                }
                else
                {
                    trainers.FirstOrDefault(a => a.Name == trainerName).Pokemons.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));
                }
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                foreach (var trainer in trainers)
                {
                    trainer.WinBadget(input);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(a => a.Badgets))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}