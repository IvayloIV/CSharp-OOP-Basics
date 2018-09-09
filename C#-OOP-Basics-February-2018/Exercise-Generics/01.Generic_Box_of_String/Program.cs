using System;
using System.Collections.Generic;

namespace _01.Generic_Box_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var results = new List<Box<string>>();
            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();
                results.Add(new Box<string>(value));
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
