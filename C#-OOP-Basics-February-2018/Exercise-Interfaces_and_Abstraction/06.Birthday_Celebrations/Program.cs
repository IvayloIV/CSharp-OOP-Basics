using System;
using System.Collections.Generic;

namespace _06.Birthday_Celebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<IBirthdate>();
            ReadInputs(collection);
            var year = Console.ReadLine();
            PrintFilterYear(collection, year);
        }

        private static void PrintFilterYear(List<IBirthdate> collection, string year)
        {
            foreach (var item in collection)
            {
                if (item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }

        private static void ReadInputs(List<IBirthdate> collection)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Citizen":
                        AddNewCitizen(collection, tokens);
                        break;
                    case "Pet":
                        AddNewPet(collection, tokens);
                        break;
                }
            }
        }

        private static void AddNewPet(List<IBirthdate> collection, string[] tokens)
        {
            var name = tokens[1];
            var birthdate = tokens[2];
            var pet = new Pet(name, birthdate);
            collection.Add(pet);
        }

        private static void AddNewCitizen(List<IBirthdate> collection, string[] tokens)
        {
            var name = tokens[1];
            var age = int.Parse(tokens[2]);
            var id = tokens[3];
            var birthdate = tokens[4];
            var citizen = new Citizen(name, age, id, birthdate);
            collection.Add(citizen);
        }
    }
}
