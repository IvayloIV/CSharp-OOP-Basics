using System;
using System.Collections.Generic;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            ReadAnimals(animals);
            PrintAnimals(animals);
        }

        private static void ReadAnimals(List<Animal> animals)
        {
            string type;
            while ((type = Console.ReadLine()) != "Beast!")
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var gender = tokens[2];
                try
                {
                    AddNewAnimal(animals, type, name, age, gender);
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        private static void AddNewAnimal(List<Animal> animals, string type, string name, int age, string gender)
        {
            var animal = AnimalFactory.GetAnimal(type, name, age, gender);
            animals.Add(animal);
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}