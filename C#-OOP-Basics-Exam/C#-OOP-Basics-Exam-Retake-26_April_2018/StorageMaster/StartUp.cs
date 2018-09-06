using System;
using System.Linq;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var storageMaster = new StorageMaster();
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                var result = string.Empty;
                tokens = tokens.Skip(1).ToList();
                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            result = storageMaster.AddProduct(tokens[0], double.Parse(tokens[1]));
                            break;
                        case "RegisterStorage":
                            result = storageMaster.RegisterStorage(tokens[0], tokens[1]);
                            break;
                        case "SelectVehicle":
                            result = storageMaster.SelectVehicle(tokens[0], int.Parse(tokens[1]));
                            break;
                        case "LoadVehicle":
                            result = storageMaster.LoadVehicle(tokens);
                            break;
                        case "SendVehicleTo":
                            result = storageMaster.SendVehicleTo(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            break;
                        case "UnloadVehicle":
                            result = storageMaster.UnloadVehicle(tokens[0], int.Parse(tokens[1]));
                            break;
                        case "GetStorageStatus":
                            result = storageMaster.GetStorageStatus(tokens[0]);
                            break;
                    }
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException err)
                {
                    Console.WriteLine("Error: " + err.Message);
                }
            }
            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}