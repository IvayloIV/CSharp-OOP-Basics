using System;

namespace _02.Vehicles_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle(nameof(Car));
            Vehicle trunk = CreateVehicle(nameof(Truck));
            Vehicle bus = CreateVehicle(nameof(Bus));

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                var typeVihicle = tokens[1];
                try
                {
                    switch (typeVihicle)
                    {
                        case "Car":
                            MakeCommand(command, tokens[2], car);
                            break;
                        case "Truck":
                            MakeCommand(command, tokens[2], trunk);
                            break;
                        case "Bus":
                            MakeCommand(command, tokens[2], bus);
                            break;
                    }
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            PrintVehicles(car, trunk, bus);
        }

        private static void PrintVehicles(Vehicle car, Vehicle trunk, Vehicle bus)
        {
            Console.WriteLine(car);
            Console.WriteLine(trunk);
            Console.WriteLine(bus);
        }

        private static Vehicle CreateVehicle(string vehicle)
        {
            var tokens = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(tokens[1]);
            var lettersPerKm = double.Parse(tokens[2]);
            var tankCapacity = double.Parse(tokens[3]);
            switch (vehicle)
            {
                case "Car":
                    return new Car(fuelQuantity, lettersPerKm, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, lettersPerKm, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, lettersPerKm, tankCapacity);
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
            else if (command == "DriveEmpty")
            {
                var distance = double.Parse(element);
                var result = vihicle.DriveEmpty(distance);
                Console.WriteLine(result);
            }
        }
    }
}