using System;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var lake = new Lake(numbers);

            var result = string.Empty;
            foreach (var jump in lake)
            {
                result += jump + ", ";
            }
            Console.WriteLine(result.Substring(0, result.Length - 2));
        }
    }
}