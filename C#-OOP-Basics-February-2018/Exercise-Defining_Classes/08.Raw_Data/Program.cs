using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var model = tokens[0];
                var engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                var cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                var tire1 = new Tire(double.Parse(tokens[5]), int.Parse(tokens[6]));
                var tire2 = new Tire(double.Parse(tokens[7]), int.Parse(tokens[8]));
                var tire3 = new Tire(double.Parse(tokens[9]), int.Parse(tokens[10]));
                var tire4 = new Tire(double.Parse(tokens[11]), int.Parse(tokens[12]));
                cars.Add(new Car(model, engine, cargo, tire1, tire2, tire3, tire4));
            }
            var command = Console.ReadLine();
            var filterCars = new List<Car>();
            if (command == "fragile")
            {
                filterCars = cars.Where(a => a.Tires.Any(b => b.Pressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                filterCars = cars.Where(a => a.Engine.Power > 250).ToList();
            }
            foreach (var car in filterCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}