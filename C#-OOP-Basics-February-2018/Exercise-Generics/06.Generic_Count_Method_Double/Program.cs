using System;
using System.Collections.Generic;

namespace _06.Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<double>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var item = double.Parse(Console.ReadLine());
                collection.Add(item);
            }

            var elemenetForCompare = double.Parse(Console.ReadLine());
            var box = new Box<double>(elemenetForCompare);

            Console.WriteLine(Compare(collection, box.Value));
        }

        public static int Compare<T>(IList<T> items, T elementCompare)
            where T : IComparable<T>
        {
            var counter = 0;

            foreach (var item in items)
            {
                if (elementCompare.CompareTo(item) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
