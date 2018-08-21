using System;
using System.Collections.Generic;

namespace _09.Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);
            var rectangles = new Dictionary<string, Rectangle>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var id = line[0];
                rectangles[id] = new Rectangle(id, double.Parse(line[1]), double.Parse(line[2]),
                    double.Parse(line[3]), double.Parse(line[4]));
            }
            for (int i = 0; i < m; i++)
            {
                var line = Console.ReadLine().Split();
                var firstId = line[0];
                var secondId = line[1];
                Console.WriteLine(rectangles[firstId].IsInside(rectangles[secondId]) ? "true" : "false");
            }
        }
    }
}
