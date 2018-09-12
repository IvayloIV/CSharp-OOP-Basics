using System;
using System.Linq;

namespace _08.Pet_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            var clinicProcessor = new ClinicProcessor();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var tokens = Console.ReadLine().Split().ToArray();
                    var command = tokens[0];
                    tokens = tokens.Skip(1).ToArray();
                    ImplementCommand(clinicProcessor, tokens, command);
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        private static void ImplementCommand(ClinicProcessor clinicProcessor, string[] tokens, string command)
        {
            switch (command)
            {
                case "Create" when tokens[0] == "Pet":
                    clinicProcessor.CreatePet(tokens);
                    break;
                case "Create" when tokens[0] == "Clinic":
                    clinicProcessor.CreateClinic(tokens);
                    break;
                case "Add":
                    Console.WriteLine(clinicProcessor.AddPetToClinic(tokens));
                    break;
                case "HasEmptyRooms":
                    Console.WriteLine(clinicProcessor.HasEmptyRooms(tokens));
                    break;
                case "Release":
                    Console.WriteLine(clinicProcessor.Release(tokens));
                    break;
                case "Print":
                    clinicProcessor.Print(tokens);
                    break;
            }
        }
    }
}