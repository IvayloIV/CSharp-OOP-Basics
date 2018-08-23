using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] carTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var newCar = new Car(carTokens);
                cars.Add(newCar);
            }
            string command = Console.ReadLine();
            List<string> filterCars = GetFilteredCars(command, cars);
            Console.WriteLine(string.Join(Environment.NewLine, filterCars));
        }

        private static List<string> GetFilteredCars(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                return cars
                    .Where(car => car.Cargo.CargoType == "fragile" && car.Tires.Any(tire => tire.Pressure < 1))
                    .Select(car => car.Model)
                    .ToList();
            }
            return cars
                .Where(car => car.Cargo.CargoType == "flamable" && car.Engine.Power > 250)
                .Select(car => car.Model)
                .ToList();
        }
    }
}
