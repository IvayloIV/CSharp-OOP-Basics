using System;
using System.Collections.Generic;

namespace _02.Generic_Box_of_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var results = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                var value = int.Parse(Console.ReadLine());
                results.Add(new Box<int>(value));
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}