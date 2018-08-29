using System;
using System.Collections.Generic;

namespace _10.Explicit_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var citizen = new List<Citizen>();
            ReadAndAddCitizen(citizen);
            PrintCitizen(citizen);
        }

        private static void PrintCitizen(List<Citizen> citizen)
        {
            foreach (var man in citizen)
            {
                var person = (IPerson)man;
                var resident = (IResident)man;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }

        private static void ReadAndAddCitizen(List<Citizen> citizen)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                AddNewCitizen(citizen, tokens);
            }
        }

        private static void AddNewCitizen(List<Citizen> citizen, string[] tokens)
        {
            var name = tokens[0];
            var country = tokens[1];
            var age = int.Parse(tokens[2]);
            var newCitizen = new Citizen(name, country, age);
            citizen.Add(newCitizen);
        }
    }
}