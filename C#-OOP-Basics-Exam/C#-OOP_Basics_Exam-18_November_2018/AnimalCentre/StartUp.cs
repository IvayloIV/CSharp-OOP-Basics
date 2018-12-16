using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre animalCentre = new AnimalCentre();
            var type = typeof(AnimalCentre);
            ReadCommands(animalCentre, type);

            Console.WriteLine(animalCentre.GetAdoptedAnimals());
        }

        private static void ReadCommands(AnimalCentre animalCentre, Type type)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();
                string command = tokens[0];
                string[] elements = tokens.Skip(1).ToArray();

                var method = type.GetMethod(command);
                string result = string.Empty;

                try
                {
                    result = InvokeCommand(animalCentre, command, elements, result);
                    Console.WriteLine(result);
                }
                catch (TargetInvocationException error)
                {
                    Console.WriteLine($"{error.InnerException.GetType().Name}: {error.InnerException.Message}");
                }
                catch (InvalidOperationException error)
                {
                    Console.WriteLine($"InvalidOperationException: {error.Message}");
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"ArgumentException: {error.Message}");
                }
            }
        }

        private static string InvokeCommand(AnimalCentre animalCentre, string command, string[] elements, string result)
        {
            if (command == "RegisterAnimal")
            {
                result = animalCentre.RegisterAnimal(elements[0], elements[1], int.Parse(elements[2]), int.Parse(elements[3]), int.Parse(elements[4]));
            }
            else if (command == "History")
            {
                result = animalCentre.History(elements[0]);
            }
            else if (command == "Adopt")
            {
                result = animalCentre.Adopt(elements[0], elements[1]);
            }
            else if (command == "Chip")
            {
                result = animalCentre.Chip(elements[0], int.Parse(elements[1]));
            }
            else if (command == "Vaccinate")
            {
                result = animalCentre.Vaccinate(elements[0], int.Parse(elements[1]));
            }
            else if (command == "Fitness")
            {
                result = animalCentre.Fitness(elements[0], int.Parse(elements[1]));
            }
            else if (command == "Play")
            {
                result = animalCentre.Play(elements[0], int.Parse(elements[1]));
            }
            else if (command == "DentalCare")
            {
                result = animalCentre.DentalCare(elements[0], int.Parse(elements[1]));
            }
            else if (command == "NailTrim")
            {
                result = animalCentre.NailTrim(elements[0], int.Parse(elements[1]));
            }

            return result;
        }
    }
}