using System;
using System.Collections.Generic;

namespace _03.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>();

            shapes.Add(new Circle(4));
            shapes.Add(new Rectangle(4, 4));
            shapes.Add(new Rectangle(2, 5));
            shapes.Add(new Circle(1));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.CalculatePerimeter());
            }
        }
    }
}