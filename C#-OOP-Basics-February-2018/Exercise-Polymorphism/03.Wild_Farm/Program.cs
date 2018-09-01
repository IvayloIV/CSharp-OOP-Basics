using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var animalsTokens = command.Split();
                var newAnimal = AnimalFactory.GetAnimal(animalsTokens);
                var foodTokens = Console.ReadLine().Split();
                var food = FoodFactory.GetFood(foodTokens);
                Console.WriteLine(newAnimal.ProduceSound());
                animals.Add(newAnimal);
                try
                {
                    newAnimal.TryToEatFood(food);
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            PrintAnimals(animals);
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}