using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            ReadAndAddPeople(people);

            var personN = int.Parse(Console.ReadLine());
            var currentPerson = people[personN - 1];
            var equalPersons = FindEqualPeople(people, personN, currentPerson);

            PrintResult(people, equalPersons);
        }

        private static void PrintResult(List<Person> people, int equalPersons)
        {
            if (equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPersons} {people.Count - equalPersons} {people.Count}");
            }
        }

        private static int FindEqualPeople(List<Person> people, int personN, Person currentPerson)
        {
            var equalPersons = 1;

            for (int i = 0; i < people.Count; i++)
            {
                if (personN - 1 == i)
                {
                    continue;
                }
                if (currentPerson.CompareTo(people[i]) == 0)
                {
                    equalPersons++;
                }
            }

            return equalPersons;
        }

        private static void ReadAndAddPeople(List<Person> people)
        {
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                people.Add(new Person(name, age, town));
            }
        }
    }
}