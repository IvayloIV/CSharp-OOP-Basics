using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Food_Shortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<IBuyer>();
            var n = int.Parse(Console.ReadLine());
            ReadAndAddPeople(people, n);
            BuyFood(people);
            PrintTotalFood(people);
        }

        private static void PrintTotalFood(List<IBuyer> people)
        {
            Console.WriteLine(people.Sum(a => a.Food));
        }

        private static void BuyFood(List<IBuyer> people)
        {
            string commandName;
            while ((commandName = Console.ReadLine()) != "End")
            {
                var person = people.FirstOrDefault(a => a.Name == commandName);
                if (person != null)
                {
                    person.BuyFood();
                }
            }
        }

        private static void ReadAndAddPeople(List<IBuyer> people, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                if (tokens.Length == 4)
                {
                    AddNewCitizen(people, tokens, name, age);
                }
                else
                {
                    AddNewRebel(people, tokens, name, age);
                }
            }
        }

        private static void AddNewRebel(List<IBuyer> people, string[] tokens, string name, int age)
        {
            var group = tokens[2];
            var newRebel = new Rebel(name, age, group);
            people.Add(newRebel);
        }

        private static void AddNewCitizen(List<IBuyer> people, string[] tokens, string name, int age)
        {
            var id = tokens[2];
            var birthdate = tokens[3];
            var newCitizen = new Citizen(name, age, id, birthdate);
            people.Add(newCitizen);
        }
    }
}