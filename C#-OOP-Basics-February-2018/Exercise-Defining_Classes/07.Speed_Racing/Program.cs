using System;
using System.Collections.Generic;

namespace _07.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumption = double.Parse(input[2]);
                cars[model] = new Car(model, fuelAmount, fuelConsumption);
            }
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                var tokens = line.Split();
                var model = tokens[1];
                var amountOfKm = int.Parse(tokens[2]);
                cars[model].TravelDistance(amountOfKm);
            }
            foreach (var item in cars)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}