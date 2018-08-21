using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Family_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var peoples = new List<Person>();
            var relations = new List<string>();
            while (true)
            {
                var newLine = Console.ReadLine();
                if (newLine == "End")
                {
                    break;
                }
                var tokens = newLine.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 2)
                {
                    relations.Add(newLine);
                }
                else
                {
                    var personTokens = newLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var name = personTokens[0] + " " + personTokens[1];
                    var birthdate = personTokens[2];
                    if (peoples.Any(a => a.Name == name))
                    {
                        peoples.FirstOrDefault(a => a.Name == name).Birthdate = birthdate;
                    }
                    else if (peoples.Any(a => a.Birthdate == birthdate))
                    {
                        peoples.FirstOrDefault(a => a.Birthdate == birthdate).Name = name;
                    }
                    else
                    {
                        peoples.Add(new Person(name, birthdate));
                    }
                }
            }
            var newPerson = CheckIfExist(peoples, input);
            peoples.Add(newPerson);
            foreach (var relation in relations)
            {
                var tokens = relation.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                CreatePeople(peoples, tokens[0], tokens[1]);
            }
            Console.WriteLine(peoples.FirstOrDefault(a => a.Name == input || a.Birthdate == input));
        }

        private static void CreatePeople(List<Person> peoples, string parent, string children)
        {
            var currentParent = CheckIfExist(peoples, parent);
            var currentChild = CheckIfExist(peoples, children);
            peoples.Add(currentParent);
            peoples.Add(currentChild);
            currentParent.Children.Add(currentChild);
            currentChild.Parents.Add(currentParent);
        }

        private static Person CheckIfExist(List<Person> peoples, string parent)
        {
            var newPerson = new Person();
            if (parent.IndexOf("/") == -1)
            {
                if (peoples.Any(a => a.Name == parent))
                {
                    newPerson = peoples.FirstOrDefault(a => a.Name == parent);
                }
                else
                {
                    newPerson.Name = parent;
                }
            }
            else
            {
                if (peoples.Any(a => a.Birthdate == parent))
                {
                    newPerson = peoples.FirstOrDefault(a => a.Birthdate == parent);
                }
                else
                {
                    newPerson.Birthdate = parent;
                }
            }
            return newPerson;
        }
    }
}