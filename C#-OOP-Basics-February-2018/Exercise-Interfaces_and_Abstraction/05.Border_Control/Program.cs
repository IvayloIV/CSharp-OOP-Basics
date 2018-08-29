using System;
using System.Collections.Generic;

namespace _05.Border_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            var humans = new List<IHuman>();
            ReadInput(humans);
            var id = Console.ReadLine();
            PrintFilteredHumans(humans, id);
        }

        private static void PrintFilteredHumans(List<IHuman> humans, string id)
        {
            foreach (IHuman human in humans)
            {
                if (human.Id.EndsWith(id))
                {
                    Console.WriteLine(human.Id);
                }
            }
        }

        private static void ReadInput(List<IHuman> humans)
        {
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    AddCitizen(humans, tokens);
                }
                else if (tokens.Length == 2)
                {
                    AddRobot(humans, tokens);
                }
            }
        }

        private static void AddCitizen(List<IHuman> humans, string[] tokens)
        {
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var id = tokens[2];
            humans.Add(new Citizen(name, age, id));
        }

        private static void AddRobot(List<IHuman> humans, string[] tokens)
        {
            var model = tokens[0];
            var id = tokens[1];
            humans.Add(new Robot(model, id));
        }
    }
}