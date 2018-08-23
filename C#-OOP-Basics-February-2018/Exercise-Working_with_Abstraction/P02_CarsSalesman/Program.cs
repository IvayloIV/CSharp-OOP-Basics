using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());
            AddAllEngines(engines, engineCount);

            int carCount = int.Parse(Console.ReadLine());
            AddAllCars(cars, engines, carCount);

            PrintResult(cars);
        }

        private static void PrintResult(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void AddAllCars(List<Car> cars, List<Engine> engines, int carCount)
        {
            for (int i = 0; i < carCount; i++)
            {
                string[] carTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = carTokens[0];
                string engineModel = carTokens[1];
                Engine engine = engines.FirstOrDefault(x => x.model == engineModel);
                AddNewCar(cars, carTokens, model, engine);
            }
        }

        private static void AddAllEngines(List<Engine> engines, int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                string[] engineTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = engineTokens[0];
                int power = int.Parse(engineTokens[1]);
                AddNewEngine(engines, engineTokens, model, power);
            }
        }

        private static void AddNewCar(List<Car> cars, string[] carTokens, string model, Engine engine)
        {
            int weight = -1;

            Car newCar;
            if (carTokens.Length == 3 && int.TryParse(carTokens[2], out weight))
            {
                newCar = new Car(model, engine, weight);
            }
            else if (carTokens.Length == 3)
            {
                string color = carTokens[2];
                newCar = new Car(model, engine, color);
            }
            else if (carTokens.Length == 4)
            {
                string color = carTokens[3];
                newCar = new Car(model, engine, int.Parse(carTokens[2]), color);
            }
            else
            {
                newCar = new Car(model, engine);
            }
            cars.Add(newCar);
        }

        private static void AddNewEngine(List<Engine> engines, string[] engineTokens, string model, int power)
        {
            int displacement = -1;

            Engine newEngine;
            if (engineTokens.Length == 3 && int.TryParse(engineTokens[2], out displacement))
            {
                newEngine = new Engine(model, power, displacement);
            }
            else if (engineTokens.Length == 3)
            {
                string efficiency = engineTokens[2];
                newEngine = new Engine(model, power, efficiency);
            }
            else if (engineTokens.Length == 4)
            {
                string efficiency = engineTokens[3];
                displacement = int.Parse(engineTokens[2]);
                newEngine = new Engine(model, power, displacement, efficiency);
            }
            else
            {
                newEngine = new Engine(model, power);
            }
            engines.Add(newEngine);
        }
    }
}