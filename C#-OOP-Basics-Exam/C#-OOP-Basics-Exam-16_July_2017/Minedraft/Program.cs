using System;
using System.Linq;

namespace Minedraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var draftManager = new DraftManager();
            string command;
            while ((command = Console.ReadLine()) != "Shutdown")
            {
                var tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var currentCommaned = tokens[0];
                tokens.RemoveAt(0);
                var result = string.Empty;
                switch (currentCommaned)
                {
                    case "RegisterHarvester":
                        result =  draftManager.RegisterHarvester(tokens);
                        break;
                    case "RegisterProvider":
                        result = draftManager.RegisterProvider(tokens);
                        break;
                    case "Day":
                        result = draftManager.Day();
                        break;
                    case "Mode":
                        result = draftManager.Mode(tokens);
                        break;
                    case "Check":
                        result = draftManager.Check(tokens);
                        break;
                }
                Console.WriteLine(result);
            }
            Console.WriteLine(draftManager.ShutDown());
        }
    }
}