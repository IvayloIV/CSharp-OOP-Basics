using System;

namespace _08.Custom_List_Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList<string>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split();
                var command = tokens[0];
                ImplementCommand(customList, tokens, command);
            }
        }

        private static void ImplementCommand(CustomList<string> customList, string[] tokens, string command)
        {
            switch (command)
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Sort":
                    customList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(customList.ToString());
                    break;
            }
        }
    }
}