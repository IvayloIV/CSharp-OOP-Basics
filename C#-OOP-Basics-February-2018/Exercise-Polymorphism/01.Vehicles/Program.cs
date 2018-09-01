using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle(nameof(Car));
            Vehicle trunk = CreateVehicle(nameof(Truck));

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                var typeVihicle = tokens[1];
                if (typeVihicle == "Car")
                {
                    MakeCommand(command, tokens[2], car);
                }
                else if (typeVihicle == "Truck")
                {
                    MakeCommand(command, tokens[2], trunk);
                }
            }
            PrintVehicles(car, trunk);
        }

        private static void PrintVehicles(Vehicle car, Vehicle trunk)
        {
            Console.WriteLine(car);
            Console.WriteLine(trunk);
        }

        private static Vehicle CreateVehicle(string vehicle)
        {
            var tokens = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(tokens[1]);
            var lettersPerKm = double.Parse(tokens[2]);
            switch (vehicle)
            {
                case "Car":
                    return new Car(fuelQuantity, lettersPerKm);
                case "Truck":
                    return new Truck(fuelQuantity, lettersPerKm);
                default:
                    throw new ArgumentException("Not existence vehicle!");
            }
        }

        private static void MakeCommand(string command, string element, Vehicle vihicle)
        {
            if (command == "Drive")
            {
                var distance = double.Parse(element);
                var result = vihicle.Drive(distance);
                Console.WriteLine(result);
            }
            else if (command == "Refuel")
            {
                var liters = double.Parse(element);
                vihicle.Refuel(liters);
            }
        }
    }
}