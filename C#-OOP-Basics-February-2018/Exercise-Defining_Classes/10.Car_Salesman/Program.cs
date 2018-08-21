using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var lane = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = lane[0];
                var power = int.Parse(lane[1]);
                if (lane.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (lane.Length == 3)
                {
                    if (int.TryParse(lane[2], out int displacement))
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, lane[2]));
                    }
                }
                else
                {
                    engines.Add(new Engine(model, power, int.Parse(lane[2]), lane[3]));
                }
            }
            var m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                var lane = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var model = lane[0];
                var engine = engines.Where(a => a.Model == lane[1]).FirstOrDefault();
                if (lane.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (lane.Length == 3)
                {
                    if (int.TryParse(lane[2], out int weight))
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, lane[2]));
                    }
                }
                else
                {
                    cars.Add(new Car(model, engine, int.Parse(lane[2]), lane[3]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}