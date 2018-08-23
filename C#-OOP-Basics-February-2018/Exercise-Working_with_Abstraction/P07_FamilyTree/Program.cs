using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();

            var mainPerson = Person.CreatePerson(personInput);
            familyTree.Add(mainPerson);

            ReadInput(familyTree);
            PrintMainPerson(mainPerson);
        }

        private static void ReadInput(List<Person> familyTree)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    AddNewFamily(familyTree, tokens);
                }
                else
                {
                    AddInfoForPerson(familyTree, tokens);
                }
            }
        }

        private static void AddInfoForPerson(List<Person> familyTree, string[] tokens)
        {
            tokens = tokens[0].Split();
            string name = $"{tokens[0]} {tokens[1]}";
            string birthday = tokens[2];

            Person person = FullPersonFilds(familyTree, name, birthday);

            Person dublicate = familyTree
                .Where(p => p.Name == name || p.Birthday == birthday)
                .Skip(1)
                .FirstOrDefault();

            if (dublicate != null)
            {
                RemoveDublicate(familyTree, person, dublicate);
            }
        }

        private static void PrintMainPerson(Person mainPerson)
        {
            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine(child);
            }
        }

        private static Person FullPersonFilds(List<Person> familyTree, string name, string birthday)
        {
            var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
            if (person == null)
            {
                person = new Person();
                familyTree.Add(person);
            }
            person.Name = name;
            person.Birthday = birthday;
            return person;
        }

        private static void RemoveDublicate(List<Person> familyTree, Person person, Person dublicate)
        {
            familyTree.Remove(dublicate);
            person.Parents.AddRange(dublicate.Parents);
            person.Parents = person.Parents.Distinct().ToList();
            foreach (var parent in dublicate.Parents)
            {
                SetPropOfDublicate(person, dublicate, parent.Children);
            }

            person.Children.AddRange(dublicate.Children);
            person.Children = person.Children.Distinct().ToList();
            foreach (var child in dublicate.Children)
            {
                SetPropOfDublicate(person, dublicate, child.Parents);
            }
        }

        private static void SetPropOfDublicate(Person person, Person dublicate, List<Person> type)
        {
            var indexOfParent = type.IndexOf(dublicate);
            if (indexOfParent == -1)
            {
                type.Add(person);
            }
            else
            {
                type[indexOfParent] = person;
            }
        }

        private static void AddNewFamily(List<Person> familyTree, string[] tokens)
        {
            string parent = tokens[0];
            string child = tokens[1];
            Person currentPerson = SetParent(familyTree, parent);
            SetChild(familyTree, currentPerson, child);
        }

        private static Person SetParent(List<Person> familyTree, string parent)
        {
            Person currentPerson = familyTree.FirstOrDefault(p => p.Birthday == parent || p.Name == parent);

            if (currentPerson == null)
            {
                currentPerson = Person.CreatePerson(parent);
                familyTree.Add(currentPerson);
            }

            return currentPerson;
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = familyTree
                .FirstOrDefault(a => a.Name == child || a.Birthday == child);

            if (childPerson == null)
            {
                childPerson = Person.CreatePerson(child);
                familyTree.Add(childPerson);
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
        }
    }
}