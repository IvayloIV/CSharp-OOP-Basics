using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            if (people.All(a => a.Name != name))
            {
                people.Add(new Person(name));
            }
            var category = tokens[1];
            AddElement(people, category, tokens, name);
        }
        var currentName = Console.ReadLine();
        Console.WriteLine(people.FirstOrDefault(a => a.Name == currentName));
    }

    private static void AddElement(List<Person> people, string category, string[] tokens, string name)
    {
        if (category == "company")
        {
            people.FirstOrDefault(a => a.Name == name).Company = new Company(tokens[2], tokens[3], double.Parse(tokens[4]));
        }
        else if (category == "pokemon")
        {
            people.FirstOrDefault(a => a.Name == name).Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
        }
        else if (category == "parents")
        {
            people.FirstOrDefault(a => a.Name == name).Parents.Add(new Parent(tokens[2], tokens[3]));
        }
        else if (category == "children")
        {
            people.FirstOrDefault(a => a.Name == name).Childrens.Add(new Children(tokens[2], tokens[3]));
        }
        else if (category == "car")
        {
            people.FirstOrDefault(a => a.Name == name).Car = new Car(tokens[2], int.Parse(tokens[3]));
        }
    }
}