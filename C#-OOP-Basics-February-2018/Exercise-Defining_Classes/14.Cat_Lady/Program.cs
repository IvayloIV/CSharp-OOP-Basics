using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Cat_Lady
{
    class Program
    {
        static void Main(string[] args)
        {
            var cats = new List<Cat>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                cats.Add(new Cat(tokens[0], tokens[1], double.Parse(tokens[2])));
            }
            var currentCat = Console.ReadLine();
            Console.WriteLine(cats.FirstOrDefault(a => a.Name == currentCat));
        }
    }
}
