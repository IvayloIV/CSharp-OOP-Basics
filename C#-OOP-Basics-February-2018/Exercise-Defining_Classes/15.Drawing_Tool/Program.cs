using System;

namespace _15.Drawing_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var shape = Console.ReadLine();
            var width = int.Parse(Console.ReadLine());
            var height = 0;
            if (shape == "Square")
            {
                height = width;
            }
            else
            {
                height = int.Parse(Console.ReadLine());
            }
            var figure = new DrawingTool(height, width);
            Console.WriteLine(figure.Draw());
        }
    }
}