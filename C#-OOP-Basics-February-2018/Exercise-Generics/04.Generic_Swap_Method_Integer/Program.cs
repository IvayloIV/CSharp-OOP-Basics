﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Generic_Swap_Method_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                var value =int.Parse(Console.ReadLine());
                boxes.Add(new Box<int>(value));
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToList();
            var index1 = indexes[0];
            var index2 = indexes[1];

            SwapElement(boxes, index1, index2);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        public static void SwapElement<T>(List<Box<T>> boxes, int index1, int index2)
        {
            var firstElement = boxes[index1];
            boxes[index1] = boxes[index2];
            boxes[index2] = firstElement;
        }
    }
}
