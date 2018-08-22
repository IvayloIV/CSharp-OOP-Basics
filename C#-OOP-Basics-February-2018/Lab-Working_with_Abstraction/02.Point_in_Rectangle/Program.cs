using System;
using System.Linq;

namespace _02.Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(Console.ReadLine);
            var rows = int.Parse(Console.ReadLine());
            for (int counter = 0; counter < rows; counter++)
            {
                var newPoint = new Point(Console.ReadLine);
                var contains = rectangle.Contains(newPoint);
                Console.WriteLine(contains);
            }
        }
    }
}