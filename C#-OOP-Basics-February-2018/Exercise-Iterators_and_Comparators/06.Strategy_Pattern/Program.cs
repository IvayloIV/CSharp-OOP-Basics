using System;
using System.Collections.Generic;

namespace _06.Strategy_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedSetName = new SortedSet<Person>(new PersonCompareName());
            var sortedSetAge = new SortedSet<Person>(new PersonComapreAge());

            FillSortedSets(sortedSetName, sortedSetAge);

            PrintSortedPeople(sortedSetName);
            PrintSortedPeople(sortedSetAge);
        }

        private static void FillSortedSets(SortedSet<Person> sortedSetName, SortedSet<Person> sortedSetAge)
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var newPerson = new Person(name, age);
                sortedSetName.Add(newPerson);
                sortedSetAge.Add(newPerson);
            }
        }

        private static void PrintSortedPeople(SortedSet<Person> collection)
        {
            foreach (var person in collection)
            {
                Console.WriteLine(person);
            }
        }
    }
}