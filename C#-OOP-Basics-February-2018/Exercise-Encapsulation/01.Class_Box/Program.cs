﻿using System;

namespace _01.Class_Box
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSerfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
    }
}